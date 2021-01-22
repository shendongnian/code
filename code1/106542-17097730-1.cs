    public sealed class ObjectTransaction:IDisposable
    {
        bool m_isDisposed;
        Dictionary<object,object> sourceObjRefHolder;
        object m_backup;
        object m_original;
        public ObjectTransaction(object obj)
        {
            sourceObjRefHolder = new Dictionary<object,object>();
            m_backup = processRecursive(obj,sourceObjRefHolder,new CreateNewInstanceResolver());
            m_original = obj;
        }
        public void Dispose()
        {
            Rollback();
        }
        public void Rollback()
        {
            if (m_isDisposed)
                return;
           
            var processRefHolder = new Dictionary<object,object>();
            var targetObjRefHolder = sourceObjRefHolder.ToDictionary(x=>x.Value,x=>x.Key);
            var originalRefResolver = new DictionaryRefResolver(targetObjRefHolder);
            processRecursive(m_backup, processRefHolder, originalRefResolver);
            dispose();
        }
        public void Commit()
        {
            if (m_isDisposed)
                return;
            //do nothing
            dispose();
        }
        void dispose()
        {
            sourceObjRefHolder = null;
            m_backup = null;
            m_original = null;
            m_isDisposed = true;
        }
        object processRecursive(object objSource, Dictionary<object,object> processRefHolder, ITargetObjectResolver targetResolver)
        {
            if (objSource == null) return null;
            if (objSource.GetType()==typeof(string) || objSource.GetType().IsClass == false) return objSource;
            if (processRefHolder.ContainsKey(objSource)) return processRefHolder[objSource];
            
            Type type = objSource.GetType();
            object objTarget = targetResolver.Resolve(objSource);
            processRefHolder.Add(objSource, objTarget);
            if (type.IsArray)
            {
                Array objSourceArray = (Array)objSource;
                Array objTargetArray = (Array)objTarget;
                for(int i=0;i<objSourceArray.Length;++i)
                {
                    object arrayItemTarget = processRecursive(objSourceArray.GetValue(i), processRefHolder, targetResolver);
                    objTargetArray.SetValue(arrayItemTarget,i);
                }
            }
            else
            {
                IEnumerable<FieldInfo> fieldsInfo = FieldInfoEnumerable.Create(type);
                foreach(FieldInfo f in fieldsInfo)
                {
                    if (f.FieldType==typeof(ObjectTransaction)) continue;
                    object objSourceField = f.GetValue(objSource);
                    object objTargetField = processRecursive(objSourceField, processRefHolder, targetResolver);
                
                    f.SetValue(objTarget,objTargetField);                    
                }
            }
            return objTarget;
        }
        interface ITargetObjectResolver
        {
            object Resolve(object objSource);
        }
        class CreateNewInstanceResolver:ITargetObjectResolver
        {
            public object Resolve(object sourceObj)
            {
                object newObject=null;
                if (sourceObj.GetType().IsArray)
                {
                    var length = ((Array)sourceObj).Length;
                    newObject = Activator.CreateInstance(sourceObj.GetType(),length);
                }
                else
                {
                    //no constructor calling, so no side effects during instantiation
                    newObject = System.Runtime.Serialization.FormatterServices.GetUninitializedObject(sourceObj.GetType());
                    
                    //newObject = Activator.CreateInstance(sourceObj.GetType());
                }
                return newObject;
            }
        }
        class DictionaryRefResolver:ITargetObjectResolver
        {
            readonly Dictionary<object,object> m_refHolder;
            
            public DictionaryRefResolver(Dictionary<object,object> refHolder)
	        {
                m_refHolder = refHolder;
	        }
            public object Resolve(object sourceObj)
            {
                if (!m_refHolder.ContainsKey(sourceObj))
                    throw new Exception("Unknown object reference");
                return m_refHolder[sourceObj];
            }
        }
    }
    class FieldInfoEnumerable
    {
        public static IEnumerable<FieldInfo> Create(Type type)
        {
            while(type!=null)
            {
                var fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                foreach(FieldInfo fi in fields)
                {
                    yield return fi; 
                }
                type = type.BaseType;
            }            
        }
    }
