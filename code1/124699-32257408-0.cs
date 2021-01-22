    class Subclass<TSubclass, T> 
    {
        static Subclass()
        {
            Values = new List<Subclass<TSubclass, T>>();
            // This line is where the magic happens
            System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(typeof(TSubclass).TypeHandle);
        }
        public Subclass()
        {
            if (!Values.Any(i => i.Value.Equals(this.Value)))
            {
                Values.Add(this);
            } 
        }
    
        public T Value { get; set; }
    
        public static List<Subclass<TSubclass, T>> Values { get; private set; }
    }
    
    class Superclass : Subclass<Superclass, int>
    {
        public static Superclass SuperclassA1 = new Superclass { Value = 1 };
        public static Superclass SuperclassA2 = new Superclass { Value = 2 };
        public static Superclass SuperclassA3 = new Superclass { Value = 3 };
        public static Superclass SuperclassA4 = new Superclass { Value = 4 }; 
    }
    
    public class Program
    {
        public static void Main()
        {
            foreach (var value in Superclass.Values)
            {
                Console.WriteLine(value.Value);
            }
            Console.ReadKey();
        }
    }
