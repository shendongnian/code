    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Reflection;
    using System.Text;
    public static class ObjectExtensions
    {
        /// <summary>
        /// Enable using reflection for setting property value 
        /// on every object giving property name and value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target"></param>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool SetProperty<T>(this T target, string propertyName, object value)
        {
            PropertyInfo pi = target.GetType().GetProperty(propertyName);
            if (pi == null)
            {
                Debug.Assert(false);
                return false;
            }
            try
            {
                // Convert the value to set to the properly type
                value = ConvertValue(pi.PropertyType, value);
                // Set the value with the correct type
                pi.SetValue(target, value, null);
            }
            catch (Exception ex)
            {
                Debug.Assert(false);
                return false;
            }
            return true;
        }
        
        private static object ConvertValue(Type propertyType, object value)
        {
            // Check each type You need to handle
            // In this way You have control on conversion operation, before assigning value
            if (propertyType == typeof(int) ||
                propertyType == typeof(int?))
            {
                int intValue;
                if (int.TryParse(value.ToString(), out intValue))
                    value = intValue;
            }
            else if (propertyType == typeof(byte) ||
                    propertyType == typeof(byte?))
            {
                byte byteValue;
                if (byte.TryParse(value.ToString(), out byteValue))
                    value = byteValue;
            }
            else if (propertyType == typeof(string))
            {
                value = value.ToString();
            }
            else
            {
                // Extend Your own handled types
                Debug.Assert(false);
            }
            return value;
        }
    }
