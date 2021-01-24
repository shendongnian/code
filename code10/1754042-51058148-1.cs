    public abstract class Coffee
    {
        public void MakeCoffee()
        {
            PutMilk();
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
            if (HaveMilk())
            {
                Console.WriteLine($"I put 100Cc of Milk");
            }
        }
    }
