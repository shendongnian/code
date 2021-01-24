    class Cat
    {
        public int Id { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Cat cat1 = new Cat { Id = 1 };
            Cat cat2 = new Cat { Id = 2 };
            ICollection<Cat> cats = new List<Cat>();
            cats.Add(cat1);
            cats.Add(cat2);
            TestMethod<ICollection<Cat>>(cats);
            TestMethod<Cat>(cat1);
        }
        public static void TestMethod<T>(T parameter)
        {
            if (typeof(T) == typeof(ICollection<Cat>))  //if (parameter is ICollection<Cat>)
            {
                ICollection<Cat> cats = parameter as ICollection<Cat>;
                //Count your cats in count variable
                int count = cats.Count;
            }
            else
            if (typeof(T) == typeof(Cat))  // if (parameter is Cat)
            {
                Cat cat = parameter as Cat;
                //Get id of your cat in id variable
                int id = cat.Id;
            }
        }
    }
