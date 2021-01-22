    public class Person
    {
        public int Age { get; set;  }
        public string Name { get; set; }
        public void LockThis()
        {
            lock (this)
            {
                System.Threading.Thread.Sleep(10000);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var nancy = new Person {Name = "Nancy Drew", Age = 15};
            var a = new Thread(nancy.LockThis);
            a.Start();
            var b = new Thread(Timewarp);
            b.Start(nancy);
            Thread.Sleep(10);
            var anotherNancy = new Person { Name = "Nancy Drew", Age = 50 };
            var c = new Thread(NameChange);
            c.Start(anotherNancy);
            a.Join();
            Console.ReadLine();
        }
        static void Timewarp(object subject)
        {
            var person = subject as Person;
            if (person == null) throw new ArgumentNullException("subject");
            // A lock does not make the object read-only.
            lock (person.Name)
            {
                while (person.Age <= 23)
                {
                    // There will be a lock on 'person' due to the LockThis method running in another thread
                    if (Monitor.TryEnter(person, 10) == false)
                    {
                        Console.WriteLine("'this' person is locked!");
                    }
                    else Monitor.Exit(person);
                    person.Age++;
                    if(person.Age == 18)
                    {
                        // Changing the 'person.Name' value doesn't change the lock...
                        person.Name = "Nancy Smith";
                    }
                    Console.WriteLine("{0} is {1} years old.", person.Name, person.Age);
                }
            }
        }
        static void NameChange(object subject)
        {
            var person = subject as Person;
            if (person == null) throw new ArgumentNullException("subject");
            // You should avoid locking on strings, since they are immutable.
            if (Monitor.TryEnter(person.Name, 30) == false)
            {
                Console.WriteLine("Failed to obtain lock on 50 year old Nancy, because Timewarp(object) locked on string \"Nancy Drew\".");
            }
            else Monitor.Exit(person.Name);
            if (Monitor.TryEnter("Nancy Drew", 30) == false)
            {
                Console.WriteLine("Failed to obtain lock using 'Nancy Drew' literal, locked by 'person.Name' since both are the same object thanks to inlining!");
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
