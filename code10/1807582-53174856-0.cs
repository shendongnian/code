    public delegate void AllPropertiesSetDelegate();
    public class Test
    {
        public event AllPropertiesSetDelegate AllPropertiesSet;
        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                CheckAllProperties();
            }
        }
        private int _id;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                CheckAllProperties();
            }
        }
        private string _name;
        private void CheckAllProperties()
        {
            if (Name != null && Id != null)
            {
                AllPropertiesSet.Invoke();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Test t = new Test();
            t.AllPropertiesSet += delegate { AllPropsSet(); };
            t.Id = 1;
            t.Name = "asd";
            Console.ReadKey();
        }
        static void AllPropsSet()
        {
            Console.WriteLine("All properties have been set.");
        }
    }
