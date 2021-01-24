	public class Person
	{
		public string Name { get; private set; }
		public int Age { get; private set; }
		public bool Alive { get; private set; }
		public bool AbilityToKill { get; private set; }
		public int HitPoints { get; private set; }
	
		public int Attack(Person victim, int points)
		{
			var hp = victim.HitPoints;
			if (this.AbilityToKill)
			{
				victim.HitPoints -= points;
				if (victim.HitPoints <= 0)
				{
					victim.HitPoints = 0;
					victim.Alive = false;
				}
			}
			hp -= victim.HitPoints;
			return hp;
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
