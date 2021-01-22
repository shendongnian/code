    class Program
    {
        class Service 
        { 
            public int ID { get; set; } 
        }
    
        class CustomService 
        { 
            public Service srv { get; set; } 
        }
    
        static void Main(string[] args)
        {
            var serviceProp = typeof(CustomService).GetProperty("srv");
            var idProp = serviceProp.PropertyType.GetProperty("ID");
            var service = new CustomService
            {
                srv = new Service { ID = 5 }
            };
            var srvValue = serviceProp.GetValue(service, null);
            var idValue = (int)idProp.GetValue(srvValue, null);
            Console.WriteLine(idValue);
        }
    }
