    public static class JobFunctions
    {
    	const string Namespace = "EFTest";
    
    	[ModelDefinedFunction(nameof(MetadataValueXml), Namespace, "'' + CAST(Job.MetadataValue AS String)")]
    	public static string MetadataValueXml(this Job job) => job.MetadataValue;
    
    	[ModelDefinedFunction(nameof(ParametersValueXml), Namespace, "'' + CAST(Job.ParametersValue AS String)")]
    	public static string ParametersValueXml(this Job job) => job.ParametersValue;
    
    	[ModelDefinedFunction(nameof(AttributesValueXml), Namespace, "'' + CAST(Job.AttributesValue AS String)")]
    	public static string AttributesValueXml(this Job job) => job.AttributesValue;
    }
