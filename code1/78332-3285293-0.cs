    [Serializable]
    public sealed class StaticAttribute : OnMethodBoundaryAspect
    {
        public override bool CompileTimeValidate(System.Reflection.MethodBase method)
        {
            return method.IsStatic;
        }
