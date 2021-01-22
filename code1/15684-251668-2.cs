    public class Person
	{
		private int age;
		private string name;
		public int Age
		{
			get { return age; }
			set { age = value; }
		}
		public string Name
		{
			get { return name; }
			set { name = value; }
		}
		public Person(string name)
		{
			this.age = 0;
			this.name = name;
		}
		public void LockThis()
		{
			lock (this)
			{
				System.Threading.Thread.Sleep(10000);
			}
		}
		public void GrowOld()
		{
			this.age++;
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			Person nancy = new Person("Nancy Drew");
			nancy.Age = 15;
			Thread a = new Thread(nancy.LockThis);
			Thread b = new Thread(Program.Timewarp);
			Thread c = new Thread(Program.NameChange);
			a.Start();
			b.Start(nancy);
			c.Start(nancy);
			a.Join();
			Console.ReadLine();
		}
		static void Timewarp(object subject)
		{
			Person person = subject as Person;
			if (person == null) throw new ArgumentNullException("subject");
			lock (person.Name)
			{
				while (person.Age <= 23)
				{
					if (Monitor.TryEnter(person, 10) == false)
					{
						Console.WriteLine("'this' person is locked!");
					}
					else Monitor.Exit(person);
					person.GrowOld();
					Console.WriteLine("{0} is {1} years old.", person.Name, person.Age);
				}
			}
		}
		static void NameChange(object subject)
		{
			Person person = subject as Person;
			if (person == null) throw new ArgumentNullException("subject");
			// Be careful about using strings as locks
			if (Monitor.TryEnter(person.Name, 30) == false)
			{
				Console.WriteLine("Failed to obtain lock on 'person.Name' on first try, wait longer.");
			}
			else Monitor.Exit(person.Name);
			if (Monitor.TryEnter("Nancy Drew", 30) == false)
			{
				Console.WriteLine("Failed to obtain lock using 'Nancy Drew' literal, locked by 'person.Name' since both are the same thanks to inlining!");
			}
			else Monitor.Exit("Nancy Drew");
			if (Monitor.TryEnter(person.Name, 10000))
			{
				string oldName = person.Name;
				person.Name = "Nancy Callahan";
				Console.WriteLine("Name changed from '{0}' to '{1}'.", oldName, person.Name);
			}
			else Monitor.Exit(person.Name);
		}
	}
