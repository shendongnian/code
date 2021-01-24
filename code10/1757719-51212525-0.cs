    public interface IWeapon
    {
        int Damage { get; }
        int Range { get; }
        void Attack();
    }
    
    public class Weapon : IWeapon
    {
        public int Damage { get; private set; }
        public int Range { get; private set; }
    
        public Weapon(int damage, int range)
        {
            Damage = damage;
            Range = range;
        }
    
        public virtual void Attack()
        {
            Console.WriteLine("Weapon: Attack");
        }
    }
    
    public class Sword : Weapon
    {
        //some sword properties here...
    
        public Sword(int damage, int range) : base(damage, range)
        {
    
        }
    
        public override void Attack()
        {
            Console.WriteLine("Weapon Sword: Attack");
        }
    }
    
    public class Bow : Weapon
    {
        //some bow properties here...
    
        public Bow(int damage, int range) : base(damage, range)
        {
    
        }
    
        public override void Attack()
        {
            Console.WriteLine("Weapon Bow: Attack");
        }
    }
    
    public class Hammer : Weapon
    {
        //some hammer properties here...
    
        public Hammer(int damage, int range) : base(damage, range)
        {
    
        }
    
        public override void Attack()
        {
            Console.WriteLine("Weapon Hammer: Attack");
        }
    }
    
    class Program
    {
        public static void Main(string[] args)
        {
            IWeapon hammerWeapon = new Hammer(15, 10);
            hammerWeapon.Attack();
        }
    }
