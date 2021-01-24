    internal static ParameterExpression Make(Type type, string name, bool isByRef) {
        if (isByRef) {
            return new ByRefParameterExpression(type, name);
        } else {
            if (!type.IsEnum) {
