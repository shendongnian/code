    using System;
    using System.Collections.Generic;
    namespace CustomExtensions
    {
    /// <summary>
    /// uses extension methods to convert enums with hypens in their names to underscore and other variants
    public static class EnumExtensions
    {
        /// <summary>
        /// Gets the description string, if available. Otherwise returns the name of the enum field
        /// LthWrapper.POS.Dollar.GetString() yields "$", an impossible control character for enums
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetStringSlow(this Enum value)
        {
            Type type = value.GetType();
            string name = Enum.GetName(type, value);
            if (name != null)
            {
                System.Reflection.FieldInfo field = type.GetField(name);
                if (field != null)
                {
                    System.ComponentModel.DescriptionAttribute attr =
                           Attribute.GetCustomAttribute(field,
                             typeof(System.ComponentModel.DescriptionAttribute)) as System.ComponentModel.DescriptionAttribute;
                    if (attr != null)
                    {
                        //return the description if we have it
                        name = attr.Description; 
                    }
                }
            }
            return name;
        }
        
        /// <summary>
        /// Converts a string to an enum field using the string first; if that fails, tries to find a description
        /// attribute that matches. 
        /// "$".ToEnum<LthWrapper.POS>() yields POS.Dollar
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T ToEnumSlow<T>(this string value) //, T defaultValue)
        {
            T theEnum = default(T);
            Type enumType = typeof(T);
            //check and see if the value is a non attribute value
            try
            {
                theEnum = (T)Enum.Parse(enumType, value);
            }
            catch (System.ArgumentException e)
            {
                bool found = false;
                foreach (T enumValue in Enum.GetValues(enumType))
                {
                    System.Reflection.FieldInfo field = enumType.GetField(enumValue.ToString());
                    System.ComponentModel.DescriptionAttribute attr =
                               Attribute.GetCustomAttribute(field,
                                 typeof(System.ComponentModel.DescriptionAttribute)) as System.ComponentModel.DescriptionAttribute;
                    if (attr != null && attr.Description.Equals(value))
                    {
                        theEnum = enumValue;
                        found = true;
                        break;
                     
                    }
                }
                if( !found )
                    throw new ArgumentException("Cannot convert " + value + " to " + enumType.ToString());
            }
            return theEnum;
        }
    }
    }
