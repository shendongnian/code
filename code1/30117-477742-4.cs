            public static bool TryParseIndirect(Type t, string s, out object val)
        {
            MethodInfo mGeneric =typeof(Parsing).GetMethod("TryParse");
            MethodInfo mSpecific = mGeneric.MakeGenericMethod(new Type[] { t });
            object oVal = null;
            object[] oArgs = new object[] { s, oVal };
            bool bRes = (bool)mSpecific.Invoke(null, oArgs);
            val = oArgs[1];
            return bRes;
        }
