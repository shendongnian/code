        private const BindingFlags Flags = BindingFlags.NonPublic |
            BindingFlags.Public | BindingFlags.Instance;
        public static bool HasOverride(this Type type, string name, params Type[] argTypes)
        {
            MethodInfo method = type.GetMethod(name, Flags, null, CallingConventions.HasThis,
                argTypes, new ParameterModifier[0]);
            return method != null && method.HasOverride();
        }
