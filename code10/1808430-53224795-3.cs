    public class PositioningModule
    {
        public string IpAddress { get; set; }
        public PositioningModuleStatus PositioningModuleStatus { get; set; }
        public PositioningModule(string ipAddress, PositioningModuleStatus positioningModuleStatus)
        {
            IpAddress = ipAddress;
            PositioningModuleStatus = positioningModuleStatus;
        }
    }
	
