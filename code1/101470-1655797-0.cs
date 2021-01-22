    public class Foo
    {
        public static void Main()
        {
            int[] x = new int[] {1,2,3};
            Bar(x);
            Bar(10,11,12);
        }
    
        public static void Bar(params int[] quux)
        {
            foreach(int i in quux)
            {
                System.Console.WriteLine(i);
            }
        }
    }
