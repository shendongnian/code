        public class ServiceStation
        {
          ServiceStationUtility  _gateUtility;
    
        public ServiceStation()
        {
            this._gateUtility = new ServiceStationUtility();
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
    
       public class ServiceStationUtility 
       {
           public void OpenGate()
           {
            //Open the shop if the time is later than 9 AM
           }
    
          public void CloseGate()
          {
            //Close the shop if the time has crossed 6PM
          }
        }
    
