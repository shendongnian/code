    // Anemic domain model (simple entity)
    public class Car
    {
        public int Size { get; set;}
    }
    // Domain model with business rules
    public class Car
    {
        public int Size { get; private set; }
        public void SetSize (int size)
        {
            // check to make sure size is within constraints
            if (size < 0 || size > 100)
                throw new ArgumentException(nameof(size));
            
            Size = size;
        }
    }
    // Value object
    public class Car
    {
        public Car (int size) 
        {
            // check constraints of size
            Size = size;
        }
        public int Size { get; }
    }
