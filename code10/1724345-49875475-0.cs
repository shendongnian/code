    namespace jsonTests
    {
        public class DeviceTypeWithResponseTypeMapper
        {
            public string DeviceType { get; set; }
            public List<string> ResponseTypes { get; set; }
        }
    
        public class RootObject
        {
            public List<DeviceTypeWithResponseTypeMapper> DeviceTypeWithResponseTypeMapper { get; set; }
        }
    }
