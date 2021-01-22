    public class StateObject1
    {
        public string parameter1;
        public int parameter2;
    }
    public class StateObject2
    {
        public DateTime parameter1;
        public DateTime parameter2;
    }
  
    public void Handler1(object stateObject)
    {
        if (!(stateObject is StateObject1))
            throw new ArgumentException("Invalid state object type");
        ...
    }
    public void Handler2(object stateObject)
    {
        if (!(stateObject is StateObject2))
            throw new ArgumentException("Invalid state object type");
        ...
    }
