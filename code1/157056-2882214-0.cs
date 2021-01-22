    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ModuleActivationButtonAttribute : ExportAttribute
    {
        public Enum TargetRegion { get; set; }
        public ModuleActivationButtonAttribute(object targetRegion) : base(typeof(IModuleActivationButton))
        {
            TargetRegion = targetRegion as Enum;
        }
    }
