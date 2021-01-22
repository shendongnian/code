    using System;
    using System.ComponentModel;
    using System.Linq;
    
    namespace Extensions {
    
    public static class T_Extensions {
            public static string Description<T>(this T t) =>
                ((DescriptionAttribute[])t
                ?.GetType()
                ?.GetField(t?.ToString())
                ?.GetCustomAttributes(typeof(DescriptionAttribute), false))
                ?.Select(a => a?.Description)
                ?.FirstOrDefault() 
                ?? string.Empty;  
        }
    }
