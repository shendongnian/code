    public class Sample<Zebra> where Zebra: Mammal
    {
        Zebra ChildObject { set; get; }
        void Test()
        {
            ChildObject = new Tiger(); // Bang!
        }
    }
