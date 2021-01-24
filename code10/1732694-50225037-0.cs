    public class Player
    {
        public string Name { get; set; }
        public int Health { get; set; } = 100;
        public int Damage { get; set; }
        public bool IsAlive { get; set; }
        
        public Player(string name, int health, int damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
            IsAlive = true;
        }
        public void TakeDamageFromEnemy(Enemy enemy)
        {
            if(IsAlive)
            {
                Health -= enemy.Damage;
                if (Health < 0)
                {
                    IsAlive = false;
                    MessageBox.Show("Player is dead!");
                }
            }
        }
        public void DoDamageToEnemy(Enemy enemy)
        {
            if(enemy.IsAlive)
            {
                enemy.Health -= Damage;
                if (Health < 0)
                {
                    IsAlive = false;
                }
            }
        }
    }
    public class Enemy
    {
        
        private string Name { get; set; }
        private int Health { get; set; }= 100;
        private int Damage { get;  set;}
        public string enemyMessages { get; set; }
        public bool IsAlive { get; set; } 
        public Enemy(string name, int health, int damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
            IsAlive = true;
        }
        //This is likely replaced by the Player's DoDamageToEnemy method.
        public void enemyTakeDamage()
        {
            int takenDamage;
        }   
    }
    public class Program
    {
        static void Main(string[] args)
        {
            Player playerOne = new Player("Zach", 100, 20);
            Enemy enemyOne = new Enemy("Trogg",15,5);
            Enemy enemyTwo = new Enemy("Dragon",1000,50);
            playerOne.TakeDamageFromEnemy(enemyTwo);
            playerOne.TakeDamageFromEnemy(enemyOne);
            playerOne.DoDamageToEnemy(enemyOne);
            playerOne.TakeDamageFromEnemy(enemyTwo);
            Console.ReadLine();
        }
    }
