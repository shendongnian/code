    public class A
    {
        public IFieldSimpleItem Create()
        {
            IFieldSimpleItem created = InternalCreate();
            CheckCreatedType(created);
            return created;
        }
        protected virtual IFieldSimpleItem InternalCreate()
        {
            return new SimpleImpl();
        }
        private void CheckCreatedType(IFieldSimpleItem item)
        {
            Type inspect = this.GetType();
            bool keepgoing = true;
            while (keepgoing)
            {
                string name = inspect.FullName;
                if (CheckDelegateMethods.ContainsKey(name))
                {
                    var checkDelegate = CheckDelegateMethods[name];
                    if (!checkDelegate(item))
                        throw new Exception("failed check");
                }
                if (inspect == typeof(A))
                {
                    keepgoing = false;
                }
                else
                {
                    inspect = inspect.BaseType;
                }
            }
            
            // base class doesn't care. compiler guarantees IFieldSimpleItem
        }
        private static Dictionary<string,Func<IFieldSimpleItem,bool>> CheckDelegateMethods = new Dictionary<string,Func<IFieldSimpleItem,bool>>();
        protected static void RegisterCheckOnType(string name, Func<IFieldSimpleItem,bool> checkMethod )
        {
            CheckDelegateMethods.Add(name, checkMethod);
        }
    }
    public class B : A
    {
        static B()
        {
            RegisterCheckOnType(typeof(B).FullName, o => o is IFieldNormalItem);
        }
        protected override IFieldSimpleItem InternalCreate()
        {
            // does not call base class.
            return new NormalImpl();
        }
    }
