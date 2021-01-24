		public void Hit()
		{
			if(Alive)
			{
				if(HitPoints > 0)
				{
					HitPoints -= 1;
				}
				else
				{
					Alive = false;
				}
			}
		}
		public bool Kill(Person person)
		{
			if(!AbilityToKill)
			{
				Console.WriteLine("You don't have ability to kill! You cannont kill {0}.", person.Name);
				return false;
			}
			while(person.Alive)
			{
				person.Hit();
			}
			Console.WriteLine("{0} is dead.", person.Name);
			return true;
		}
