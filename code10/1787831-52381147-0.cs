    interface IClassModel
    {
        int Num { get; set; }
    }
    class ClassOne: IClassModel
    {
        public int Num { get; set; }
    }
    class ClassTwo: IClassModel
    {
        public int Num { get; set; }
    }
    class Program
    {
        static void ProduceClass<T>() where T : IClassModel, new()
        {
            T value = new T();
            value.Num = 1;
        }
        static void Main(string[] args)
        {
            ProduceClass<ClassOne>();
        }
    }
