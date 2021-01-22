    class MyClass
    {
        public int ObjectNumber { get; set; }
        public string SomeVariable { get; set; }
        public string AnotherVariable { get; set; }
    }
    // You should use keyboard input value for this 
    int objectsToCreate = 10;
    // Create an array to hold all your objects
    MyClass[] myObjects = new MyClass[objectsToCreate];
    for (int i = 0; i < objectsToCreate; i++)
    {
        // Instantiate a new object, set it's number and
        // some other properties
        myObjects[i] = new MyClass()
        {
            ObjectNumber = i + 1,
            SomeVariable = "SomeValue",
            AnotherVariable = "AnotherValue"
        };
    }
