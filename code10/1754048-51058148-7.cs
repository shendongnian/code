    public abstract class Coffee
    {
        public void MakeCoffee()
        {
            PutMilk();
        }
    }
    public class SimpleCoffeWithMilk : Coffee
    {
        public bool HaveMilk()
        {
            return true;
        }
        public override void PutMilk()
        {
            if (HaveMilk())
            {
                Console.WriteLine($"I put 100Cc of Milk");
            }
        }
    }
