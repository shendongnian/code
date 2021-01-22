    public class ExplicitLifetimeManager :
        LifetimeManager
    {
        object Value;
        public override object GetValue()
        {
            return Value;
        }
        public override void SetValue(object newValue)
        {
            Value = newValue;
        }
        public override void RemoveValue()
        {
            Value = null;
        }
    }
