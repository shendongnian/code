    interface ICalculations {
        double Calculate(IScenario scenario);
    }
    
    interface IScenario{
        double Execute();
        IScenario Clone();
    }
    
    public class CalculationsCacher: ICalculations {
        IDictionary<IScenario, double> _cache;
        public CalculationsCacher(IDictionary<IScenario, double> existingCache = new Dictionary<IScenario, double>()){
            //c#4 has optional parameters
            _cache = existingCache
        }
        public double Calculate(IScenario scenario){
            if(_cache.ContainsKey[scenario]) return _cache[scenario];
    
            _cache[scenario.Clone()] = scenario.Execute();
            return _cache[scenario];
        }
    }
    
    class AccelerationScenario: IScenario{
        // properties
        public AccelerationScenario(double distance, TimeSpan time){
           // set things
        }
    
        public double Execute(){
          //calculate
        }
    
        public IScenario Clone(){
          //use contructor to build a new one
        } 
        public override int GetHashCode(){
          //generate the hashcode
        }
        public override bool Equals(object obj){
          //you should also override this when you override GetHashCode()
        }
    }
    //somewhere in your app
    var scenario = new AccerlationScenario(/* values */);
    return calculations.Calculate(scenario);
