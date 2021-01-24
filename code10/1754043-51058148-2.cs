    public abstract class Coffee
    {
        public abstract bool HaveMilk();
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
        public bool HaveMilk()
        {
            return true;
        }
        internal override void PutMilk()
        {
            Console.WriteLine($"I put 100Cc of Milk");
        }
    }
