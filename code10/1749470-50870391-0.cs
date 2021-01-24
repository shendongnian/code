    public class Program
    {
        public static void Main(string[] args)
        {
            var smartLightBulb = new SmartLightBulb()
            {
                DeviceType = "deviceType",
                Model = "model"
            };
            Output(smartLightBulb);
        }
        
        public static void Output(Device device)
        {
            var smartLightBulb = (device as SmartLightBulb);
            if(smartLightBulb != null)
            {
                Console.WriteLine(smartLightBulb.Model);
            }
        }
    }
    
    public class Device
    {
        public string DeviceType { get; set; }
    }
    public class SmartLightBulb : Device
    {
        public string Model { get; set; }
    }
