    public static class Parsing
    {
        static MethodInfo findTryParseMethod(Type type)
        {
            //find member of type with signature 'static public bool TryParse(string, out T)'
            BindingFlags access = BindingFlags.Static | BindingFlags.Public;
            MemberInfo[] candidates = type.FindMembers(
                MemberTypes.Method,
                access,
                delegate(MemberInfo m, object o_ignored)
                {
                    MethodInfo method = (MethodInfo)m;
                    if (method.Name != "TryParse") return false;
                    if (method.ReturnParameter.ParameterType != typeof(bool)) return false;
                    ParameterInfo[] parms = method.GetParameters();
                    if (parms.Length != 2) return false;
                    if (parms[0].ParameterType != typeof(string)) return false;
                    if (parms[1].ParameterType != type.MakeByRefType()) return false;
                    if (!parms[1].IsOut) return false;
                    return true;
                }, null);
            if (candidates.Length > 1)
            {
                //change this to your favorite exception or use an assertion
                throw new System.Exception(String.Format(
                    "Found more than one method with signature 'public static bool TryParse(string, out {0})' in type {0}.",
                    type));
            }
            if (candidates.Length == 0)
            {
                //This type does not contain a TryParse method - replace this by your error handling of choice
                throw new System.Exception(String.Format(
                    "Found no method with signature 'public static bool TryParse(string, out {0})' in type {0}.",
                    type));
            }
            return (MethodInfo)candidates[0];
        }
        public static bool TryParse(Type t, string s, out object val)
        {
            MethodInfo method = findTryParseMethod(t); //can also cache 'method' in a Dictionary<Type, MethodInfo> if desired
            object[] oArgs = new object[] { s, null };
            bool bRes = (bool)method.Invoke(null, oArgs);
            val = oArgs[1];
            return bRes;
        }
        //if you want to use TryParse in a generic syntax:
        public static bool TryParseGeneric<T>(string s, out T val)
        {
            object oVal;
            bool bRes = TryParse(typeof(T), s, out oVal);
            val = (T)oVal;
            return bRes;
        }
    }
