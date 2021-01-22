    static class TypeExtensions {
        public static bool IsCastableTo(this Type from, Type to) {
            if (to.IsAssignableFrom(from)) {
                return true;
            }
            var methods = from.GetMethods(BindingFlags.Public | BindingFlags.Static)
                              .Where(
                                  m => m.ReturnType == to && 
                                       (m.Name == "op_Implicit" || 
                                        m.Name == "op_Explicit")
                              );
            return methods.Any();
        }
    }
