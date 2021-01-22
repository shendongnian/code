    public delegate void DynamicAction(params object[] parameters);
    static class DynamicActionBuilder
    {
        public static void PerformAction0(Action a, object[] pars) { a(); }
        public static void PerformAction1<T1>(Action<T1> a, object[] p) {
            a((T1)p[0]);
        }
        public static void PerformAction2<T1, T2>(Action<T1, T2> a, object[] p) {
            a((T1)p[0], (T2)p[1]);
        }
        //etc...
        public static DynamicAction MakeAction(object target, MethodInfo mi) {
            Type[] typeArgs =
                mi.GetParameters().Select(pi => pi.ParameterType).ToArray();
            string perfActName = "PerformAction" + typeArgs.Length;
            MethodInfo performAction =
                typeof(DynamicActionBuilder).GetMethod(perfActName);
            if (typeArgs.Length != 0)
                performAction = performAction.MakeGenericMethod(typeArgs);
            Type actionType = performAction.GetParameters()[0].ParameterType;
            Delegate action = Delegate.CreateDelegate(actionType, target, mi);
            return (DynamicAction)Delegate.CreateDelegate(
                typeof(DynamicAction), action, performAction);
        }
    }
