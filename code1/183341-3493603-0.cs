    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows.Forms;
    
    public class CustomObjectType
    {
        [Category("Standard")]
        public string Name { get; set; }
        [Category("Standard")]
        public List<CustomProperty> Properties {get;set;}
    
        public CustomObjectType()
        {
            Properties = new List<CustomProperty>();
        }
    }
    
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class Person
    {
        public string Name {get;set;}
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
    }
    
    [TypeConverter(typeof(CustomProperty.CustomPropertyConverter))]
    public class CustomProperty
    {
        public CustomProperty()
        {
            Type = typeof(int);
            Name = "SomeProperty";    
        }
    
        private class CustomPropertyConverter : ExpandableObjectConverter
        {
            public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
            {
                var stdProps = base.GetProperties(context, value, attributes);
                CustomProperty obj = value as CustomProperty;            
                PropertyDescriptor[] props = new PropertyDescriptor[stdProps.Count + 1];
                stdProps.CopyTo(props, 0);
                props[stdProps.Count] = new ObjectDescriptor(obj);
               
                return new PropertyDescriptorCollection(props);
            }
        }
        private class ObjectDescriptor : PropertyDescriptor
        {
            private readonly CustomProperty prop;
            public ObjectDescriptor(CustomProperty prop)
                : base(prop.Name, null)
            {
                this.prop = prop;
            }
            public override string Category { get { return "Standard"; } }
            public override string Description { get { return "DefaultValue"; } }
            public override string Name { get { return "DefaultValue"; } }
            public override string DisplayName { get { return "DefaultValue"; } }
            public override bool ShouldSerializeValue(object component) { return ((CustomProperty)component).DefaultValue != null; }
            public override void ResetValue(object component) { ((CustomProperty)component).DefaultValue = null; }
            public override bool IsReadOnly { get { return false; } }
            public override Type PropertyType { get { return prop.Type; } }
            public override bool CanResetValue(object component) { return true; }
            public override Type ComponentType { get { return typeof(CustomProperty); } }
            public override void SetValue(object component, object value) { ((CustomProperty)component).DefaultValue = value; }
            public override object GetValue(object component) { return ((CustomProperty)component).DefaultValue; }
        }
    
        private class CustomTypeConverter: TypeConverter
        {
            public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
            {
                return true;
            }
        
            public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
            {
                if (sourceType == typeof(string))
                    return true;
    
                return base.CanConvertFrom(context, sourceType);
            }
    
            public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
            {
                if (value.GetType() == typeof(string))
                {
                    Type t = Type.GetType((string)value);
    
                    return t;
                }
    
                return base.ConvertFrom(context, culture, value);
    
            }
    
            public override System.ComponentModel.TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
            {
                var types = new Type[] { 
                    typeof(bool), 
                    typeof(int), 
                    typeof(string), 
                    typeof(float),
                    typeof(Person),
                    typeof(DateTime)};
    
                TypeConverter.StandardValuesCollection svc =
                    new TypeConverter.StandardValuesCollection(types);
                return svc;
            }
        }
    
        [Category("Standard")]
        public string Name { get; set; }
        [Category("Standard")]
        public string Desc { get; set; }
        
        [Browsable(false)]
        
        public object DefaultValue { get; set; }
        
        Type type;
    
        [Category("Standard")]
        [TypeConverter(typeof(CustomTypeConverter))]       
        public Type Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
                if (value == typeof(string))
                    DefaultValue = "";
                else
                    DefaultValue = Activator.CreateInstance(value);
            }
        }
    }
    
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            var obj = new CustomObjectType
            {
                Name = "Foo",
                Properties =
                {
                    new CustomProperty { Name = "Bar", Type = typeof(int), Desc = "I'm a bar"},
                    new CustomProperty { Name = "When", Type = typeof(DateTime), Desc = "When it happened"},
                }
            };
            Application.Run(new Form { Controls = { new PropertyGrid { SelectedObject = obj, Dock = DockStyle.Fill } } });
        }
    }
