    public class CustomPropertyDescriptor : PropertyDescriptor
    {
        object o;
        CustomProperty p;
        internal CustomPropertyDescriptor(object owner, CustomProperty property)
            : base(property.Name, null) { o = owner; p = property; }
        public override Type PropertyType => p.Value?.GetType() ?? typeof(object);
        public override void SetValue(object c, object v) => p.Value = v; 
        public override object GetValue(object c) => p.Value;
        public override bool IsReadOnly => false;
        public override Type ComponentType => o.GetType();
        public override bool CanResetValue(object c) => false;
        public override void ResetValue(object c) { }
        public override bool ShouldSerializeValue(object c) => false;
        public override string DisplayName => p.DisplayName ?? base.DisplayName;
        public override string Description => p.Description ?? base.Description;
        public override string Category => p.Category ?? base.Category;
    }
