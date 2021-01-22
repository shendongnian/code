    public class Class1<T>
    {
        public T[] Method(params T[] args)
        {
            return args;
        }
    }
    
    public class Demo
    {
        public Demo()
        {
            var c1 = new Class1<float>();
            float[] result = c1.Method(1.1f, 2.2f);
        }
    }
