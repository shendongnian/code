     class Program
    {
        static void Main(string[] args)
        {
            stud stud = new stud() { id=10,name="test" };
            PropertyInfo[] propertyInfo;
            propertyInfo = typeof(stud).GetProperties(BindingFlags.Public|BindingFlags.Instance);
            foreach (var item in propertyInfo)
            {
                Console.WriteLine(item.Name + " : " + item.GetValue(stud));
            }
            Console.ReadLine();
        }
    }
    public class stud {
        public int id { get; set; }
        public string name { get; set; }
    }
