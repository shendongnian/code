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
					if (Monitor.TryEnter(person) == false)
					{
						Console.WriteLine("'this' person is locked!");
					}
					person.GrowOld();
					Console.WriteLine("{0} is {1} years old.", person.Name, person.Age);
				}
			}
		}
		static void NameChange(object subject)
		{
			Person person = subject as Person;
			if (person == null) throw new ArgumentNullException("subject");
			if (Monitor.TryEnter(person.Name) == false)
			{
				Console.WriteLine("Failed to obtain lock on 'person.Name' on first try, wait longer.");
				if (Monitor.TryEnter(person.Name, 10000))
				{
					string oldName = person.Name;
					person.Name = "Nancy Callahan";
					Console.WriteLine("Name changed from {0} to {1}", oldName, person.Name);
				}
			}
		}
	}
