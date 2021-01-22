    public sealed class LocalizedDisplayNameAttribute : DisplayNameAttribute
    {
        private PropertyInfo _nameProperty;
        private Type _resourceType;
        public LocalizedDisplayNameAttribute(string displayNameKey)
            : base(displayNameKey)
        {
        }
        public Type NameResourceType
        {
            get
            {
                return _resourceType;
            }
            set
            {
                _resourceType = value;
                _nameProperty = _resourceType.GetProperty(base.DisplayName, BindingFlags.Static | BindingFlags.Public);
            }
        }
        public override string DisplayName
        {
            get
            {
                if (_nameProperty == null)
                {
                    return base.DisplayName;
                }
                return (string)_nameProperty.GetValue(_nameProperty.DeclaringType, null);
            }
        }
    }
    
