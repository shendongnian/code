    public class CreatedAtPointA 
    {
        public int ExamplePropOne { get; }
        public bool ExamplePropTwo { get; }
        public CreatedAtPointA(int examplePropOne, bool examplePropTwo)
        {
            ExamplePropOne = examplePropOne;
            ExamplePropTwo = examplePropTwo;
        }
    }
    public class CreatedAtPointB : CreatedAtPointA
    {
        public string ExamplePropThree { get; }
        public CreatedAtPointB(CreatedAtPointA dataFromPointA, string examplePropThree) 
            : base(dataFromPointA.ExamplePropOne, dataFromPointA.ExamplePropTwo)
        {
            ExamplePropThree = examplePropThree;
        }
    }
