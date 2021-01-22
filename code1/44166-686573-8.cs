    public static void IsTest()
    {
        long total = 0;
        var a = new MyClassA();
        var b = new MyClassB();
        var sw = new Stopwatch();
        sw.Start();
        for (int i = 0; i < 10000000; i++)
        {
            MyBaseClass baseRef;
            if (i % 2 == 0)
                baseRef = a;//new MyClassA();
            else
                baseRef = b;// new MyClassB();
            //bool bo = baseRef is MyClassB;
            bool bo = baseRef.ClassType == MyBaseClass.ClassTypeEnum.B;
            if (bo) total += 1;
        }
        sw.Stop();
        Console.WriteLine("Is test {0} miliseconds {1}", sw.ElapsedMilliseconds, total);
    }
