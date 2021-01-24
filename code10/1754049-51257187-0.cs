    public abstract class Coffee
    {
        public void MakeCoffee()
        {
            PutMilk();
        }
        protected abstract void PutMilk();
    }
    
    public class SimpleCoffeWithMilk : Coffee
    {    
        public override void PutMilk()
        {
            Console.WriteLine($"I put 100Cc of Milk");
        }
    }
    public class SimpleCoffeNoMilk : Coffee
    {    
        public override void PutMilk()
        {
            //no op
        }
    }
