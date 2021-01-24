    class Program
    {
        static string _animal;
        static void Main(string[] args) {
            TestTable<Bird> birds1 = new TestTable<Bird>();
            birds1.Rows.Add(new Bird());
            birds1.Rows.Add(new Bird());
            TestTable<Bird> birds2 = new TestTable<Bird>();
            birds2.Rows.Add(new Bird());
            birds2.Rows.Add(new Bird());
            TestTable<Bird> allBirds = MergeTestTables<Bird>(birds1, birds2);
            int howManyBirds = allBirds.Rows.Count;
            Console.WriteLine($"There are { howManyBirds } { _animal }s.");
            Console.ReadKey(true);
        }
        public static TestTable<T> MergeTestTables<T>(params TestTable<T>[] tables) where T : Animal {
            TestTable<T> merged = new TestTable<T>();
            _animal = typeof(T).Name;
            _animal = _animal.ToLower();
            foreach (TestTable<T> table in tables) {
                    foreach (T row in table.Rows) {
                        merged.Rows.Add(row);
                    }
            }
            return merged;
        }
        public class TestTable<T> where T : Animal
        {
            public List<T> Rows { get; set; } = new List<T>();
        }
        public abstract class Animal
        {
            public int EyeCount { get; set; }
        }
        public class Bird : Animal
        {
            public int FeatherCount { get; set; }
            public bool CanFly { get; set; }
        }
        public class Fish : Animal
        {
            public int NumberOfFins { get; set; }
            public bool Depth { get; set; }
        }
    }
