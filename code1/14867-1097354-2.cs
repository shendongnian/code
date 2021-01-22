    class SomeGeneric<T>
    {
        public static int i = 0;
    }
        
    class Test
    {
        public static void main(string[] args)
        {
            SomeGeneric<int>.i = 5;
            SomeGeneric<string>.i = 10;
            Console.WriteLine(SomeGeneric<int>.i);
            Console.WriteLine(SomeGeneric<string>.i);
            Console.WriteLine(SomeGeneric<int>.i);
        }
    }
