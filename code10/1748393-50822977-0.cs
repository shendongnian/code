    public class DiscoverInternalClass
    {
        public List<InternalClassObject> FindClassMethods(Type type)
        {
            List<InternalClassObject> MethodList = new List<InternalClassObject>();
            MethodInfo[] methodInfo = type.GetMethods();
            foreach (MethodInfo m in methodInfo)
            {
                List<string> propTypeList = new List<string>();
                List<string> propNameList = new List<string>();
                string returntype = m.ReturnType.ToString();
                
                foreach (var x in m.GetParameters())
                {
                    propTypeList.Add(x.ParameterType.Name);
                    propNameList.Add(x.Name);
                    
                }
                InternalClassObject ICO = new InternalClassObject(c.Name, propNameList, propTypeList);
                MethodList.Add(ICO);
            }
            return MethodList;
        }
    }
