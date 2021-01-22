    class Program
    {
        static void Main(string[] args)
        {
            using(var dc = new DataClasses1DataContext())
            { // 1: vanilla
                dc.Log = new StringWriter();
                RoundtripAndCount("Default", dc.Persons);
                Console.WriteLine("Log: " + dc.Log.ToString().Length);
            }
            using (var dc = new DataClasses1DataContext())
            { // 2: LoadWith
                dc.Log = new StringWriter();
                var opt = new DataLoadOptions();
                opt.LoadWith<Person>(p => p.PersonPhones);
                dc.LoadOptions = opt;
                RoundtripAndCount("LoadWith", dc.Persons);
                Console.WriteLine("Log: " + dc.Log.ToString().Length);
            }
            using (var dc = new DataClasses1DataContext())
            { // 3: iterate manually
                dc.Log = new StringWriter();
                // manually iterate the data (LINQ-to-Objects)
                GC.KeepAlive(dc.Persons.AsEnumerable().Sum(p=>p.PersonPhones.Count())); // just an opaque method
                RoundtripAndCount("Enumerated", dc.Persons);
                Console.WriteLine("Log: " + dc.Log.ToString().Length);
            }
        }
        static void RoundtripAndCount(string caption, IEnumerable<Person> people)
        {
            Console.WriteLine();
            Console.WriteLine(caption);
            Console.WriteLine(new string('=', caption.Length));
            List<Person> list = people.ToList(), clone;
            using(var ms = new MemoryStream())
            {
                var ser = new DataContractSerializer(typeof (List<Person>));
                ser.WriteObject(ms, list);
                ms.Position = 0;
                clone = (List<Person>) ser.ReadObject(ms);
                Console.WriteLine("Bytes: " + ms.Length);
            }
            Func<Person, int> phoneCount = p => p.PersonPhones.HasLoadedOrAssignedValues ? p.PersonPhones.Count() : 0;
            Console.WriteLine("Original person count: " + people.Count());
            Console.WriteLine("Original phone count: " + people.Sum(phoneCount));
            Console.WriteLine("Deser person count: " + clone.Count());
            Console.WriteLine("Deser phone count: " + clone.Sum(phoneCount));
        }
    }
