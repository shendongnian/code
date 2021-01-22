    public class ListThing<TKey, TValue> : Dictionary<TKey, TValue>
    {
        public double DoubleThing { get; set; }
    
        public ListThing(double value)
        {
            DoubleThing = value;
        }
    }
