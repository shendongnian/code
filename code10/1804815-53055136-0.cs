    class BaseClass : Interface
    {
        public int PropertyOne { get; }
        public string PropertyTwo { get; }
        public BaseClass(int propertyOne, string propertyTwo)
        {
            PropertyOne = propertyOne;
            PropertyTwo = propertyTwo;
        }
    }
    interface Interface
    {
        int PropertyOne { get; }
        string PropertyTwo { get; }
     }
