    public class IxData
            {
                public string IxRepo { get; set; }
            }
    
            public class DeviceData
            {
                public Dictionary<string, IxData> Models { get; set; }
                public Dictionary<string, IxData> CrmWeb { get; set; }
                public Dictionary<string, IxData> Rarautomation { get; set; }
            }
