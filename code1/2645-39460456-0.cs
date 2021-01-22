     /*
    This is working program in Visual Studio.  It is not running in fiddler because of infinite loop in code.
    This code demonstrates the difference between event and delegate
    		Event is an delegate reference with two restrictions for increased protection
    		
    			1. Cannot be invoked directly
    			2. Cannot assign value to delegate reference directly
    
    Toggle between Event vs Delegate in the code by commenting/un commenting the relevant lines
    */
    
    public class RoomTemperatureController
    {
        private int _roomTemperature = 25;//Default/Starting room Temperature
        private bool _isAirConditionTurnedOn = false;//Default AC is Off
        private bool _isHeatTurnedOn = false;//Default Heat is Off
        private bool _tempSimulator = false;
        public  delegate void OnRoomTemperatureChange(int roomTemperature); //OnRoomTemperatureChange is a type of Delegate (Check next line for proof)
        // public  OnRoomTemperatureChange WhenRoomTemperatureChange;// { get; set; }//Exposing the delegate to outside world, cannot directly expose the delegate (line above), 
    	public  event OnRoomTemperatureChange WhenRoomTemperatureChange;// { get; set; }//Exposing the delegate to outside world, cannot directly expose the delegate (line above), 
    
        public RoomTemperatureController()
        {
            WhenRoomTemperatureChange += InternalRoomTemperatuerHandler;
        }
        private void InternalRoomTemperatuerHandler(int roomTemp)
        {
            System.Console.WriteLine("Internal Room Temperature Handler - Mandatory to handle/ Should not be removed by external consumer of ths class: Note, if it is delegate this can be removed, if event cannot be removed");
        }
        
        //User cannot directly asign values to delegate (e.g. roomTempControllerObj.OnRoomTemperatureChange = delegateMethod (System will throw error)
        public bool TurnRoomTeperatureSimulator
        {
            set
            {
                _tempSimulator = value;
                if (value)
                {
                    SimulateRoomTemperature(); //Turn on Simulator				
                }
            }
            get { return _tempSimulator; }
        }
        public void TurnAirCondition(bool val)
        {
            _isAirConditionTurnedOn = val;
            _isHeatTurnedOn = !val;//Binary switch If Heat is ON - AC will turned off automatically (binary)
            System.Console.WriteLine("Aircondition :" + _isAirConditionTurnedOn);
            System.Console.WriteLine("Heat :" + _isHeatTurnedOn);
    
        }
        public void TurnHeat(bool val)
        {
            _isHeatTurnedOn = val;
            _isAirConditionTurnedOn = !val;//Binary switch If Heat is ON - AC will turned off automatically (binary)
            System.Console.WriteLine("Aircondition :" + _isAirConditionTurnedOn);
            System.Console.WriteLine("Heat :" + _isHeatTurnedOn);
    
        }
    
        public async void SimulateRoomTemperature()
        {
            while (_tempSimulator)
            {
                if (_isAirConditionTurnedOn)
                    _roomTemperature--;//Decrease Room Temperature if AC is turned On
                if (_isHeatTurnedOn)
                    _roomTemperature++;//Decrease Room Temperature if AC is turned On
                System.Console.WriteLine("Temperature :" + _roomTemperature);
                if (WhenRoomTemperatureChange != null)
                    WhenRoomTemperatureChange(_roomTemperature);
                System.Threading.Thread.Sleep(500);//Every second Temperature changes based on AC/Heat Status
            }
        }
    
    }
    
    public class MySweetHome
    {
        RoomTemperatureController roomController = null;
        public MySweetHome()
        {
            roomController = new RoomTemperatureController();
            roomController.WhenRoomTemperatureChange += TurnHeatOrACBasedOnTemp;
            //roomController.WhenRoomTemperatureChange = null; //Setting NULL to delegate reference is possible where as for Event it is not possible.
            //roomController.WhenRoomTemperatureChange.DynamicInvoke();//Dynamic Invoke is possible for Delgate and not possible with Event
            roomController.SimulateRoomTemperature();
            System.Threading.Thread.Sleep(5000);
            roomController.TurnAirCondition (true);
            roomController.TurnRoomTeperatureSimulator = true;
    
        }
        public void TurnHeatOrACBasedOnTemp(int temp)
        {
            if (temp >= 30)
                roomController.TurnAirCondition(true);
            if (temp <= 15)
                roomController.TurnHeat(true);
    
        }
    	public static void Main(string []args)
    	{
    		MySweetHome home = new MySweetHome();
    	}
    
    
    }
