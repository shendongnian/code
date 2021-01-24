	public class Person
	{
		public string Name { get; private set; }
		public int Age { get; private set; }
		public Alive Alive { get; private set; }
		public AbilityToKill AbilityToKill { get; private set; }
		public int HitPoints { get; private set; }
	
		public int Attack(Person victim, int points)
		{
			var hp = victim.HitPoints;
			if (this.AbilityToKill == AbilityToKill.Yes)
			{
				victim.HitPoints -= points;
				if (victim.HitPoints <= 0)
				{
					victim.HitPoints = 0;
					victim.Alive = Alive.No;
				}
			}
			hp -= victim.HitPoints;
			return hp;
		}
	
		public Person(string name, int age, Alive alive, AbilityToKill abilityToKill, int hitPoints)
		{
			this.HitPoints = hitPoints;
			this.AbilityToKill = abilityToKill;
			this.Alive = alive;
			this.Name = name;
			this.Age = age;
		}
	}
	
	public enum Alive { Yes, No }
	public enum AbilityToKill { Yes, No }
