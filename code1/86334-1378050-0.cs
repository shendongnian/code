     static void T(Array a)
        {
            if (a is int[])
                Console.WriteLine("Int");
            else
                if (a is float[])
                    Console.WriteLine("Float");
                else
                    ....
    
        }
        static void Main(){
            T(new int[]{30});
            float[] a = { 11 };
            T(a);
        }
