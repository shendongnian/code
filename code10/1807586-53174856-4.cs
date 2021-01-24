    public delegate void AllPropertiesSetDelegate();
    public class Test
    {
        public delegate void AllPropertiesSetDelegate(object sender, EventArgs args);
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
            //Comparing Id to null is pointless here because it is not nullable.
            if (Name != null && Id != null)
            {
                AllPropertiesSet?.Invoke(this, new EventArgs());
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
