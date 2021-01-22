    Dictionary<BrakeType, BrakeStrategy> strategyList = new Dictionary<BrakeType, BrakeStrategy>();
    
    strategyList.Add(BrakeType.ABS, new ABSBrakes());
    strategyList.Add(BrakeType.Disc, new DiscBrakes());
    strategyList.Add(BrakeType.RearDrum, new RearDrumBrakes());
    
    public class Car
    {
        public BrakeType TypeOfBrake {get; set;}
    
        public void Brake()
        {
            strategyList[TypeOfBrake].Brake();
        }
    }
