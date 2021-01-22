     public static void Main(string[] args)
        {
            //int a=10;
            //change(ref a);
            //Console.WriteLine(a);
            // Console.Read();
            int b;
            change2(out b);
            Console.WriteLine(b);
            Console.Read();
        }
        // static void change(ref int a)
        //{
        //    a = 20;
        //}
         static void change2(out int b)
         {
             b = 20;
         }
