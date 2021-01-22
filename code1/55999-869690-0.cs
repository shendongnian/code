    [AttributeUsage(AttributeTargets.Parameter)]
    public class CanBeNullAttribute : Attribute
    {
        private readonly bool canBeNull;
        public CanBeNullAttribute()
            : this(true)
        {
        }
        public CanBeNullAttribute(bool canBeNull)
        {
            this.canBeNull = canBeNull;
        }
        public bool AllowNull
        {
            get { return canBeNull; }
        }
    }
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class EnforceNullConstraintAttribute : OnMethodInvocationAspect
    {
        public override void OnInvocation(MethodInvocationEventArgs eventArgs)
        {
            object[] arguments = eventArgs.GetArgumentArray();
            ParameterInfo[] parameters = eventArgs.Delegate.Method.GetParameters();
            for (int i = 0; i < arguments.Length; i++)
            {
                if (arguments[i] != null) continue;
                foreach (CanBeNullAttribute attribute in parameters[i].GetCustomAttributes(typeof(CanBeNullAttribute), true))
                {
                    if (!attribute.AllowNull) throw new ArgumentNullException(parameters[i].Name);
                }
            }
            base.OnInvocation(eventArgs);
        }
    }
