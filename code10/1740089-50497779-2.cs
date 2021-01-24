    public class ServiceStation
    {
        IGateUtility _gateUtility;
    
        public ServiceStation(IGateUtility gateUtility)
        {
            this._gateUtility = gateUtility;
        }
    
        public void OpenForService()
        {
            _gateUtility.OpenGate();
        }
    
        public void DoService()
        {
            //Check if service station is opened and then
            //complete the vehicle service
        }
    
        public void CloseForDay()
        {
            _gateUtility.CloseGate();
        }
    }
    
    public interface IGateUtility
    {
        void OpenGate();
    
        void CloseGate();
    }
