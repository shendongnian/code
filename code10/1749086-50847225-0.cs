    [WMIClass("__InstanceModificationEvent")]
    public class ModificationEvent
    {
        public string TargetInstance { get; set; }
    
        [WMIProperty("TIME_CREATED")]
        public long Time { get; set; }
    }
