    public abstract class Coffee
    {
        public void MakeCoffee()
        {
            if (HaveMilk())
            {
                PutMilk();
            }
        }
    }
    public class SimpleCoffeWithMilk : Coffee
    {
        public override bool HaveMilk()
        {
            return true;
        }
        internal override void PutMilk()
        {
            Console.WriteLine($"I put 100Cc of Milk");
        }
    }
