    public enum StateKey{
        AL = 1,AK,AS,AZ,AR,CA,CO,CT,DE,DC,FM,FL,GA,GU,
        HI,ID,IL,IN,IA,KS,KY,LA,ME,MH,MD,MA,MI,MN,MS,
        MO,MT,NE,NV,NH,NJ,NM,NY,NC,ND,MP,OH,OK,OR,PW,
        PA,PR,RI,SC,SD,TN,TX,UT,VT,VI,VA,WA,WV,WI,WY,
    }
    
    public class State
    {
        public StateKey Key {get;set;}
        public int IntKey {get {return (int)Key;}}
        public string PostalAbbreviation {get;set;}
        
    }
    
    public interface IStateRepository
    {
        State GetByKey(StateKey key);
    }
    
    public class StateRepository : IStateRepository
    {
        private static Dictionary<StateKey, State> _statesByKey;
        static StateRepository()
        {
            _statesByKey = Enum.GetValues(typeof(StateKey))
            .Cast<StateKey>()
            .ToDictionary(k => k, k => new State {Key = k, PostalAbbreviation = k.ToString()});
        }
        public State GetByKey(StateKey key)
        {
            return _statesByKey[key];
        }
    }
    
    public class Foo
    {
        IStateRepository _repository;
        // Dependency Injection makes this class unit-testable
        public Foo(IStateRepository repository) 
        {
            _repository = repository;
        }
        // If you haven't learned the wonders of DI, do this:
        public Foo()
        {
            _repository = new StateRepository();
        }
        
        public void DoSomethingWithAState(StateKey key)
        {
            Console.WriteLine(_repository.GetByKey(key).PostalAbbreviation);
        }
    }
