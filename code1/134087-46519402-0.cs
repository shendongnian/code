    public static class ControlExtensions
    {
        public static void InvokeIfRequired<T>(this T obj,
            Action<T> action) where T : Control
        {
            if (obj.InvokeRequired)
                obj.Invoke(action);
            else
                action(obj);
        }
        public static TOut InvokeIfRequired<TIn, TOut>(this TIn obj,
            Func<TIn, TOut> func) where TIn : Control => 
            obj.InvokeRequired ? (TOut)obj.Invoke(func) : func(obj);
    }
