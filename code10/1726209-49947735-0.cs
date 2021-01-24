    public class EnvironmentSpecificAttribute : Attribute
    {
        public string TargetEnvironment { get; }
        public EnvironmentSpecificAttribute(string targetEnvironment)
        {
            TargetEnvironment = targetEnvironment;
        }
    }
