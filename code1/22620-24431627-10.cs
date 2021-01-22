    public class State:ImmutableObject<State>
    {
        public State(){}
        public State(IEnumerable<KeyValuePair<string,object>> properties):base(properties) {}
        public State(Func<IEnumerable<KeyValuePair<string, object>>> func):base(func) {}
        public readonly int SomeInt;
        public State someInt(int someInt)
        {
            return setProperty("SomeInt", someInt);
        }
        public readonly string SomeString;
        public State someString(string someString)
        {
            return setProperty("SomeString", someString);
        }
    }
   
