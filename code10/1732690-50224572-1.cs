    public class Player
    {
        public string Name;
        public int Health = 100;
        public int Damage;
        /* II. way
            public string Name {get;set}
            public int Health {get;set} = 100;
            public int Damage {get;set}
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
