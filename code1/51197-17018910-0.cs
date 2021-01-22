        /// <summary>
    /// A drop-in converter that returns the strings from 
    /// <see cref="System.ComponentModel.DescriptionAttribute"/>
    /// of items in an enumaration when they are converted to a string,
    /// like in ToString().
    /// </summary>
    public class EnumToStringUsingDescription : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return (sourceType.Equals(typeof(Enum)));
        }
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return (destinationType.Equals(typeof(String)));
        }
        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            return base.ConvertFrom(context, culture, value);
        }
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType.Equals(typeof(String)))
            {
                string name = value.ToString();
                Type effectiveType = value.GetType();          
                
                if (name != null)
                {
                    FieldInfo fi = effectiveType.GetField(name);
                    if (fi != null)
                    {
                        object[] attrs =
                        fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                        return (attrs.Length > 0) ? ((DescriptionAttribute)attrs[0]).Description : name;
                    }
                    
                }
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
        /// <summary>
        /// Coverts an Enums to string by it's description. falls back to ToString.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public string EnumToString(Enum value)
        {
            //getting the actual values
            List<Enum> values = EnumToStringUsingDescription.GetFlaggedValues(value);
            //values.ToString();
            //Will hold results for each value
            List<string> results = new List<string>();
            //getting the representing strings
            foreach (Enum currValue in values)
            {
                string currresult = this.ConvertTo(null, null, currValue, typeof(String)).ToString();;
                results.Add(currresult);
            }
            
            return String.Join("\n",results);
        }
        /// <summary>
        /// All of the values of enumeration that are represented by specified value.
        /// If it is not a flag, the value will be the only value retured
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        private static List<Enum> GetFlaggedValues(Enum value)
        {
            //checking if this string is a flaged Enum
            Type enumType = value.GetType();
            object[] attributes = enumType.GetCustomAttributes(true);
            bool hasFlags = false;
            foreach (object currAttibute in attributes)
            {
                if (enumType.GetCustomAttributes(true)[0] is System.FlagsAttribute)
                {
                    hasFlags = true;
                    break;
                }
            }
            //If it is a flag, add all fllaged values
            List<Enum> values = new List<Enum>();
            if (hasFlags)
            {
                Array allValues = Enum.GetValues(enumType);
                foreach (Enum currValue in allValues)
                {
                    if (value.HasFlag(currValue))
                    {
                        values.Add(currValue);
                    }
                }
            }
            else//if not just add current value
            {
                values.Add(value);
            }
            return values;
        }
    }
