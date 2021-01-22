    public static class Parsing
    {
        public static bool TryParse<T>(string s, out T val)
        {
            //find member of typeof(T) with signature static public bool TryParse(string, out T)
            BindingFlags access = BindingFlags.Static | BindingFlags.Public;
            MemberInfo[] candidates = typeof(T).FindMembers(
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
                    if (parms[1].ParameterType != typeof(T).MakeByRefType()) return false;                    
                    if (!parms[1].IsOut) return false;
                    return true;
                }, null);
            if (candidates.Length > 1) 
            {
                //change this to your favorite exception or use an assertion
                throw new System.Exception(String.Format(
                    "Found more than one method 'public static bool TryParse(string s, out {0})' in type {0}.",
                    typeof(T)));
            }
            if (candidates.Length == 0)
            {
                //This type does not contain a TryParse method - replace this by your error handling of choice
                throw new System.Exception(String.Format(
                    "Found no method 'public static bool TryParse(string s, out {0})' in type {0}.",
                    typeof(T)));
            }
            MethodInfo tryParseMethod = (MethodInfo)candidates[0];
            //END find member
            object oVal = null;
            object[] oArgs = new object[] { s, oVal };
            bool bRet = (bool)tryParseMethod.Invoke(null, oArgs);
            val = (T)oArgs[1];
            return bRet;
        }
    }
