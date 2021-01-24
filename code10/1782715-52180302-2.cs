    class Tiger : Mammal {}
    class Zebra : Mammal {}
    public class Sample<TAnimal> where TAnimal: Mammal
    {
        TAnimal ChildObject { set; get; }
        void Test()
        {
            ChildObject = new Tiger(); // Error: Cannot implicitly convert type 'Tiger' to 'TAnimal'
        }
    }
