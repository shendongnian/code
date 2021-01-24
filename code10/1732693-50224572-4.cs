    public class Player
    {
        public string Name;
        public int Health = 100;
        public int Damage;
        /* II. way
              public string Name {get;set;}
              public int Health {get;set;} = 100;
              public int Damage {get;set;}
          */
        /* III. way
            private string _name;
            private int _health = 100;
            private int _damage;
            public string Name {get { return _name ; } }
        */
        public Player(string name, int health, int damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }
    }
    public class Enemy
    {
        public void enemyTakeDamage()
        {
            int takenDamage;
        }
        private string Name;
        private int Health = 100;
        private int Damage;
        public string enemyMessages;
        public Enemy(string name, int health, int damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            bool dead;
            Player P1 = new Player("Zach", 100, 20);
            Console.WriteLine("Name : " + P1.Name + Environment.NewLine +
                              "Health : " + P1.Health +Environment.NewLine +
                              "Damage : "+ P1.Damage);
            Console.ReadKey();
        }
        /* static player
        public static Player P1;
        static void Main(string[] args)
        {
           bool dead;
           P1 = new Player("Zach", 100, 20);
           Console.WriteLine("Name : " + P1.Name + Environment.NewLine +
                             "Health : " + P1.Health + Environment.NewLine +
                             "Damage : " + P1.Damage);
           Console.ReadKey();
        }
       */
    }
