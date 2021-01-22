        public class MyClass {
        private readonly Hashtable hashPrefs = new Hashtable();
    
        public MyClass(int id)
        {
    
        }
    
        public Hashtable HashPrefs
        {
            set
            {
                throw new InvalidOperationException("This shouldn't happen");
            }
        }
    }
