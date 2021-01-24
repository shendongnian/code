    public abstract class Item
    {
        public abstract void PrintStats();
    }
    
    public class Weapon : Item
    {
        public int Damage { get; set; }
        public override void PrintStats()
        {
            Console.WriteLine("Damage: {0}", Damage);
        }
    }
