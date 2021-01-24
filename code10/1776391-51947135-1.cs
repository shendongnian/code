    public class Class1 : baseClass
    {
        protected override void BitThatNeedsToChange()
        {
            //the below line should only execute if b is true
            Console.WriteLine("Executing a method unique to Class1");
        }
    }
