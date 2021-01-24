    public class Person
    {
        public string Name { get; private set; }    
        public int Age { get; private set; }
        public bool Alive { get; private set; }
        public bool AbilityToKill { get; private set; }
        public int HitPoints { get; private set; }
		
		public void Hit(int points)
		{
			this.HitPoints -= points;
			if (this.HitPoints <= 0)
			{
				this.HitPoints = 0;
				this.Alive = false;
			}
		}
		
        public Person(string name, int age, bool alive, bool abilityToKill, int hitPoints)
        {
            this.HitPoints = hitPoints;
            this.AbilityToKill = abilityToKill;
            this.Alive = alive;
            this.Name = name;
            this.Age = age;
        }
    }
