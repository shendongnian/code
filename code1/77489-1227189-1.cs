    public class Init
    {
        private readonly Dictionary<Type, Action<Control>> initializers;
        ...
        public void RegisterInitializer<TControl>(Action<TControl> i)
            where T Control : Control
        {
            initializers.Add(typeof(TControl), c => i((TControl)c));
        }
        public void ApplyInitializer(Control c)
        {
           initializers[c.GetType()](c);
        }
    }
