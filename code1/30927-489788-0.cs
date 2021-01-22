      public class FunnyCounter
      {
        Dictionary<Type, int> restrictions = new Dictionary<Type, int>();
        public FunnyCounter Add<T>(int appears)
        {
          restrictions.Add(typeof(T), appears);
          return this;
        }
    
        public void PassThrough(object o)
        {
          if (restrictions.ContainsKey(o.GetType()))
            restrictions[o.GetType()] = restrictions[o.GetType()] - 1;
        }
    
        public bool SatisfiedAll()
        {
          return restrictions.Values.Aggregate(true, (b, i) => b && i == 0);
        }
