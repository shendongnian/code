    public class XmlExport : IXmlExport
    {
        private readonly IJobRepository _jobRepository;
    
        public XmlExport(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }
    }
