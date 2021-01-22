        static Dictionary<Type, MethodInfo> s_methods = new Dictionary<Type, MethodInfo>();
        static MethodInfo findTryParseMethod(Type t)
        {
                //... implement like the non-generic version of TryParse<T>
                //    TryParse(Type t, string s, out object o)
                //    (in the body replace typeof(T) with t)
                //    leaving out the code below //END find member
                return tryParseMethod;            
        }
        public static bool TryParse2(Type t, string s, out object val)
        {
            if (!s_methods.ContainsKey(t)) s_methods.Add(t, findTryParseMethod(t));
            object[] oArgs = new object[] { s, null };
            bool bRes = (bool)s_methods[t].Invoke(null, oArgs);
            val = oArgs[1];
            return bRes;
        }
