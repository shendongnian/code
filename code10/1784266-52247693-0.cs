    public class TestPlan
    {
        [ChoXmlNodeRecordField(XPath = @"/ThreadGroup/stringProp[@name=""ThreadGroup.on_sample_error""]")]
        public string NumThreads { get; set; }
        [ChoXmlNodeRecordField(XPath = @"/ThreadGroup/stringProp[@name=""ThreadGroup.ramp_time""]")]
        public int RampTime { get; set; }
    
        [ChoXmlNodeRecordField(XPath = @"/hashTree/hashTree/HTTPSamplerProxy/stringProp[@name=""HTTPSampler.path""]")]
        public string Path { get; set; }
        [ChoXmlNodeRecordField(XPath = @"/hashTree/hashTree/HTTPSamplerProxy/stringProp[@name=""HTTPSampler.domain""]")]
        public string Domain { get; set; }
    }
