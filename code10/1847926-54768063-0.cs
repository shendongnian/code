    public class Caller
    {
        protected static MethodInfo GetMethod<T>(Expression<Func<T, string>> expr) where T: class
        {
            // Execute the expression. We will get the method name.
            string methodName = expr.Compile()(null);
            // Return generic method information by name of the method
            return typeof(T).GetMethod(methodName);
        }
        public Caller()
        {
            MethodInfo method = GetMethod<ModuleBaseLogic>(m => nameof(m.Sponsor));
        }
    }
