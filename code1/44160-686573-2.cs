    static void IsTest()
    {
        DateTime start = DateTime.Now;
        for (int i = 0; i < 10000000; i++)
        {
            MyBaseClass a;
            if (i % 2 == 0)
                a = new MyClassA();
            else
                a = new MyClassB();
            bool b = a is MyClassB;
        }
        DateTime end = DateTime.Now;
        Console.WriteLine("Is test {0} miliseconds", (end - start).TotalMilliseconds);
    }
