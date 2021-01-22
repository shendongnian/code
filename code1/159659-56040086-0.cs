        public static bool HasOverridingMethod(this Type type, MethodInfo baseMethod) {
            var result =
                type.GetMethod(
                baseMethod.Name,
                BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.InvokeMethod,
                new OverridingMethodBinder( baseMethod ),
                new Type[ 0 ],
                null );
            return result != null;
        }
    internal class OverridingMethodBinder : Binder {
        private readonly MethodInfo baseMethod;
        public OverriddenMethodBinder(MethodInfo baseMethod) {
            this.baseMethod = baseMethod;
        }
        public override FieldInfo BindToField(BindingFlags bindingAttr, FieldInfo[] match, object value, CultureInfo culture) =>
            throw new NotImplementedException();
        public override MethodBase BindToMethod(BindingFlags bindingAttr, MethodBase[] match, ref object[] args, ParameterModifier[] modifiers, CultureInfo culture, string[] names, out object state) =>
            throw new NotImplementedException();
        public override MethodBase SelectMethod(BindingFlags bindingAttr, MethodBase[] match, Type[] types, ParameterModifier[] modifiers) =>
            match.OfType<MethodInfo>().FirstOrDefault( i => i.GetBaseDefinition() == baseMethod && i.DeclaringType != baseMethod.DeclaringType );
        public override PropertyInfo SelectProperty(BindingFlags bindingAttr, PropertyInfo[] match, Type returnType, Type[] indexes, ParameterModifier[] modifiers) =>
            throw new NotImplementedException();
        public override object ChangeType(object value, Type type, CultureInfo culture) => throw new NotImplementedException();
        public override void ReorderArgumentArray(ref object[] args, object state) => throw new NotImplementedException();
    }
