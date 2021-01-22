    using System;
    using System.ComponentModel;
    namespace Extensions {
        public static class T_Extensions {
            /// <summary>
            /// Gets the Description Attribute Value
            /// </summary>
            /// <typeparam name="T">Entity Type</typeparam>
            /// <param name="val">Variable</param>
            /// <returns>The value of the Description Attribute or an Empty String</returns>
            public static string Description<T>(this T t) {
                DescriptionAttribute[] attributes = (DescriptionAttribute[])t.GetType().GetField(t.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
                return attributes.Length > 0 ? attributes[0].Description : string.Empty;
            }
        }
    }
