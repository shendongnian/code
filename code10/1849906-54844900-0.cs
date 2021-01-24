        static void Main(string[] args)
        {
            WebClient client = new WebClient();
            string json = client.DownloadString("https://gis.nccde.org/agsserver/rest/services/CustomMaps/Ownership/MapServer/0/query?where=UPPER(SUBDIV)%20like%20'%25ENCLAVE%20AT%20ODESSA%25'&outFields=*&outSR=4326&f=json");
            var myModel = JsonConvert.DeserializeObject<ParcelViewModel>(json);
            Console.WriteLine("Top Level ID: " + myModel.displayFieldName);
            Console.WriteLine("Property Count: " + myModel.features.Count);
            int i = 0;
            foreach (var fac in myModel.features)
            {
                i++;
                Console.WriteLine(" ");
                Console.WriteLine("Record Number: " + i);
                Console.WriteLine("Address: " + fac.attributes.ADDRESS);
                Console.WriteLine("Owner: " + fac.attributes.CNTCTLAST);
                Console.WriteLine(" ");
            }
        }
        public class ParcelViewModel
        {
            public string displayFieldName { get; set; }
            public string geometryType { get; set; }
            public List<FeatureViewModel> features { get; set; }
        }
        public class FeatureViewModel
        {
            public AttributeViewModel attributes { get; set; }            
        }
        public class AttributeViewModel
        {
            public string ADDRESS { get; set; }
            public string CNTCTLAST { get; set; }
        }
