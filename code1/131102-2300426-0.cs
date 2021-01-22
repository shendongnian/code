    class ClassX {}
    class classPrefix_x : ClassX {}
    
    public class Program
    {
        public static void Main()
        {
            string className = "x";
            ClassX obj = (ClassX)Activator.CreateInstance(Type.GetType("classPrefix_" + className));
            Console.WriteLine(obj);
        }
    }
