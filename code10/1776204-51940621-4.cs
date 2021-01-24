    public class ProcessorServiceScope
    {
        public Service1 Service1 {get;};
        public ServiceN ServiceN {get;};
    
        public ProcessorServiceScope(Service1 service1, ServiceN serviceN)
        {
            Service1 = service1;
            ServiceN = serviceN;
        }
    }
    public class Processor1
    {
        public Processor1(ProcessorServiceScope serviceScope)
        {
            //...
        }
    }
    public class ProcessorN
    {
        public ProcessorN(ProcessorServiceScope serviceScope)
        {
            //...
        }
    }
