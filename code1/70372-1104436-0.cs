    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false)]
    public sealed class AssemblyCreatedAttribute : Attribute
    {
        public DateTime CreatedDate { get; set; }
    }
