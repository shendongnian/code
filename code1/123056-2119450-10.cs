    static class TypeExtensions {
        public static bool IsCastableTo(this Type from, Type to) {
            if (to.IsAssignableFrom(from)) {
                return true;
            }
            return from.GetMethods(BindingFlags.Public | BindingFlags.Static)
                              .Any(
                                  m => m.ReturnType == to && 
                                       (m.Name == "op_Implicit" || 
                                        m.Name == "op_Explicit")
                              );
        }
    }
