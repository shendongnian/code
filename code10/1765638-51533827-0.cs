    [XmlRoot(ElementName="JobStatus")]
    	public class JobStatus {
    		[XmlAttribute(AttributeName="StepNumber")]
    		public string StepNumber { get; set; }
    		[XmlAttribute(AttributeName="StepStatus")]
    		public string StepStatus { get; set; }
    	}
    
    	[XmlRoot(ElementName="JobstepStatus")]
    	public class JobstepStatus {
    		[XmlElement(ElementName="JobStatus")]
    		public List<JobStatus> JobStatus { get; set; }
    	}
    
    	[XmlRoot(ElementName="JobRunnerPluginStaus")]
    	public class JobRunnerPluginStaus {
    		[XmlElement(ElementName="JobstepStatus")]
    		public JobstepStatus JobstepStatus { get; set; }
    		[XmlAttribute(AttributeName="PluginName")]
    		public string PluginName { get; set; }
    	}
