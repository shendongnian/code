    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    
    namespace Rhyous.StringLibrary
    {
        public static class PrimitiveStringExtensions
        {
            public static T To<T>(this string s, T defaultValue = default(T))
                where T : IComparable, IComparable<T>, IEquatable<T>
            {
                TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
                try { return (T)converter.ConvertFromString(null, CultureInfo.InvariantCulture, s); }
                catch { return defaultValue; }
            }
            
            public static object ToType(this string s, Type type, object defaultValue = null)
            {
                MethodInfo mi = null;
                MethodInfo method = null;
                if (type.IsEnum)
                {
                    mi = typeof(StringEnumExtensions).GetMethods().FirstOrDefault(m => m.Name == "ToEnum" && m.GetParameters().Length == 4);
                    method = mi.MakeGenericMethod(type);
                    var defaultEnum = Enum.GetValues(type).GetValue(0);
                    return method.Invoke(null, new object[] { s, defaultEnum, true, true });
                }
                mi = typeof(PrimitiveStringExtensions).GetMethod("To");
                method = mi.MakeGenericMethod(type);
                // Check if it is DateTime to handle this critical .NET bug
                // https://connect.microsoft.com/VisualStudio/feedback/details/733995/datetime-default-parameter-value-throws-formatexception-at-runtime
                if (type == typeof(DateTime))
                    defaultValue = DateTime.MinValue;
                return method.Invoke(null, new object[] { s, defaultValue ?? Type.Missing });
            }
    
            public static byte ToByte(this string s, byte defaultValue = 0)
            {
                return To(s, defaultValue);
            }
    
            public static bool ToBool(this string s, bool defaultValue = false)
            {
                return To(s, defaultValue);
            }
    
            public static DateTime ToDate(this string s, DateTime defaultValue = default(DateTime))
            {
                return To(s, defaultValue);
            }
    
            public static decimal ToDecimal(this string s, decimal defaultValue = 0.0M)
            {
                return To(s, defaultValue);
            }
    
            public static double ToDouble(this string s, double defaultValue = 0.0D)
            {
                return To(s, defaultValue);
            }
    
            public static float ToFloat(this string s, float defaultValue = 0.0F)
            {
                return To(s, defaultValue);
            }
    
            public static int ToInt(this string s, int defaultValue = 0)
            {
                return To(s, defaultValue);
            }
    
            public static long ToLong(this string s, long defaultValue = 0L)
            {
                return To(s, defaultValue);
            }
    
            public static sbyte ToSByte(this string s, sbyte defaultValue = 0)
            {
                return To(s, defaultValue);
            }
    
            public static short ToShort(this string s, short defaultValue = 0)
            {
                return To(s, defaultValue);
            }
    
            public static uint ToUint(this string s, uint defaultValue = 0U)
            {
                return To(s, defaultValue);
            }
    
            public static ulong ToULong(this string s, ulong defaultValue = 0UL)
            {
                return To(s, defaultValue);
            }
    
            public static ushort ToUShort(this string s, ushort defaultValue = 0)
            {
                return To(s, defaultValue);
            }
    
            public static Guid ToGuid(this string s, Guid defaultValue = default(Guid))
            {
                return To(s, defaultValue);
            }
        }
    }
