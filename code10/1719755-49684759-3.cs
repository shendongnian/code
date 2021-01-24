    public abstract class Item
    {
        public abstract void PrintStats();
    }
    
    public class Weapon : Item
    {
        public int Damage { get; set; }
        public override void PrintInfo()
        {
            Console.WriteLine("Damage: {0}", Damage);
        }
    }
