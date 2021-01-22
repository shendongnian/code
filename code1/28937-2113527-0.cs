    static bool IsSubclassOfRawGeneric(Type generic, Type toCheck) {
        while (toCheck != typeof(object)) {
            var cur = toCheck.IsGenericType ? toCheck.GetGenericTypeDefinition() : toCheck;
              if (cur.IsGenericType && generic.GetGenericTypeDefinition() == cur.GetGenericTypeDefinition()) {
                return true;
            }
            toCheck = toCheck.BaseType;
        }
        return false;
    }
