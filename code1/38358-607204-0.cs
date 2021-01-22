    static IEnumerable<Type> GetTypesWithHelpAttribute(Assembly assembly) {
        foreach(Type type in assembly.GetTypes()) {
            if (type.GetCustomAttributes(typeof(HelpAttribute)).Length > 0) {
                yield return type;
            }
        }
    }
