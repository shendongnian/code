    public static class ReflectionExtensions {
            public static bool IsCustomValueType(this Type type) {            
                   return type.IsValueType && !type.IsPrimitive && type.Namespace != null && !type.Namespace.StartsWith("System.");
            }
        }
