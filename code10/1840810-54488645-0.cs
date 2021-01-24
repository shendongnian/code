    using System;
    using Newtonsoft.Json;
    
    namespace ConsoleApp
    {
        public class Program
        {
            public class UemSiteAvailabilityDetailsRec
            {
                public string UemAlias;
                public string IpAddress;
                public DateTimeOffset Date = new DateTimeOffset(new DateTime(1980, 7, 7));
                public string PlannedOutage;
                public string Severity;
                public string SiteName;
                public string SiteNumber;
                public string SourceAgentIp;
                public string Message;
            }
    
            static void Main(string[] args)
            {
                var toSerialize = new UemSiteAvailabilityDetailsRec();
                string val = JsonConvert.SerializeObject(toSerialize);
                Console.WriteLine(val);
                Console.ReadKey();
            }
    
        }
    }
