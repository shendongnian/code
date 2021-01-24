    using System;
    using System.ComponentModel;
    using System.ComponentModel.Design.Serialization;
    using System.Globalization;
    [TypeConverter(typeof(FruitConverter))]
    public class Fruit
    {
        public Fruit() { }
        public Fruit(bool edible, string name) : this()
        {
            Edible = edible;
            Name = name;
        }
        public bool Edible { get; set; }
        public string Name { get; set; }
    }
    public class FruitConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(InstanceDescriptor)) return true;
            return base.CanConvertTo(context, destinationType);
        }
        public override object ConvertTo(ITypeDescriptorContext context, 
            CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(InstanceDescriptor)) {
                var ci = typeof(Fruit).GetConstructor(new Type[] { 
                    typeof(bool), typeof(string) });
                var t = (Fruit)value;
                return new InstanceDescriptor(ci, new object[] { t.Edible, t.Name });
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
