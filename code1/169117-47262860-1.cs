    public class Program
    {
        public class Employee
        {
            public int id;
            public string name;
            public string lastname;
            public DateTime dateOfBirth;
    
            public Employee(int id,string name,string lastname,DateTime dateOfBirth)
            {
                this.id = id;
                this.name = name;
                this.lastname = lastname;
                this.dateOfBirth = dateOfBirth;
    
            }
        }
    
        public static void Main() => StartObjTest();
    
        #region object test
    
        public static void StartObjTest()
        {
            List<Employee> items = new List<Employee>();
    
            for (int i = 0; i < 10000000; i++)
            {
                items.Add(new Employee(i,"name" + i,"lastname" + i,DateTime.Today));
            }
    
            Test3(items, items.Count-100);
            Test4(items, items.Count - 100);
    
            Console.Read();
        }
    
    
        public static void Test3(List<Employee> items, int idToCheck)
        {
    
            Stopwatch s = new Stopwatch();
            s.Start();
    
            bool exists = false;
            foreach (var item in items)
            {
                if (item.id == idToCheck)
                {
                    exists = true;
                    break;
                }
            }
    
            Console.WriteLine("Exists=" + exists);
            Console.WriteLine("Time=" + s.ElapsedMilliseconds);
    
        }
    
        public static void Test4(List<Employee> items, int idToCheck)
        {
    
            Stopwatch s = new Stopwatch();
            s.Start();
    
            bool exists = items.Exists(e => e.id == idToCheck);
    
            Console.WriteLine("Exists=" + exists);
            Console.WriteLine("Time=" + s.ElapsedMilliseconds);
    
        }
    
        #endregion
    
    
        #region int test
        public static void StartIntTest()
        {
            List<int> items = new List<int>();
    
            for (int i = 0; i < 10000000; i++)
            {
                items.Add(i);
            }
    
            Test1(items, -100);
            Test2(items, -100);
    
            Console.Read();
        }
    
        public static void Test1(List<int> items,int itemToCheck)
        {
    
            Stopwatch s = new Stopwatch();
            s.Start();
    
            bool exists = false;
            foreach (var item in items)
            {
                if (item == itemToCheck)
                {
                    exists = true;
                    break;
                }
            }
    
            Console.WriteLine("Exists=" + exists);
            Console.WriteLine("Time=" + s.ElapsedMilliseconds);
    
        }
    
        public static void Test2(List<int> items, int itemToCheck)
        {
    
            Stopwatch s = new Stopwatch();
            s.Start();
    
            bool exists = items.Contains(itemToCheck);
    
            Console.WriteLine("Exists=" + exists);
            Console.WriteLine("Time=" + s.ElapsedMilliseconds);
    
        }
    
        #endregion
    
    }
