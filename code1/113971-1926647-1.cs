    public class MvpViewParameter : NamedParameter
    {
        public static readonly string ParameterName = typeof(MvpViewParameter).AssemblyQualifiedName;
        public MvpViewParameter(object view) : base(ParameterName, view)
        {}
    }
