    [Serializable]
    [TypeDescriptionProvider(typeof(PropertyBagDescriptionProvider))]    
    public abstract class PropertyBagWrapper
    {
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]    
        public PropertyBag DynamicProperties { get; set; }
        public object this[string name]
        {
            get { return DynamicProperties[name]; }
            set { DynamicProperties[name] = value; }
        }
        protected PropertyBagWrapper()
        {
            DynamicProperties = new PropertyBag(this.GetType());
        }
    }
    
    [Serializable]    
    public class Person : PropertyBagWrapper
    {
        [Browsable(true)]
        public string Name { get; set; }
    }
