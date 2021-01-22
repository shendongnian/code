        static Type[] MyMethod(int a, string b, DateTime c, object d)
        {
            var myParams = MethodBase.GetCurrentMethod().GetParameters();
            return myParams.Select(p => p.ParameterType).ToArray();
        }
