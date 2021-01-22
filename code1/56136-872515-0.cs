    [Benchmark]  
    public static void TestIntegerAssignment()
    {
        int i = 1;
        int j = 2;
        for (int x = 0; x < 1000000000; x++)
        {
            i = j;
        }
    }
    [Benchmark]
    public static void TestCallRoutineWithNoParameters()
    {
        for (int x = 0; x < 1000000000; x++)
        {
            TestStaticRoutine();
        }
    }
    [Benchmark]
    public static void TestCallRoutineWithOneParameter()
    {
        for (int x = 0; x < 1000000000; x++)
        {
            TestStaticRoutine2(5);
        }
    }
    [Benchmark]
    public static void TestCallRoutineWithTwoParameters()
    {
        for (int x = 0; x < 1000000000; x++)
        {
            TestStaticRoutine3(5,7);
        }
    }
    [Benchmark]
    public static void TestIntegerAddition()
    {
        int i = 1;
        int j = 2;
        int k = 3;
        for (int x = 0; x < 1000000000; x++)
        {
            i = j + k;
        }
    }
    [Benchmark]
    public static void TestIntegerSubtraction()
    {
        int i = 1;
        int j = 6;
        int k = 3;
        for (int x = 0; x < 1000000000; x++)
        {
            i = j - k;
        }
    }
    [Benchmark]
    public static void TestIntegerMultiplication()
    {
        int i = 1;
        int j = 2;
        int k = 3;
        for (int x = 0; x < 1000000000; x++)
        {
            i = j * k;
        }
    }
    [Benchmark]
    public static void TestIntegerDivision()
    {
        int i = 1;
        int j = 6;
        int k = 3;
        for (int x = 0; x < 1000000000; x++)
        {
            i = j/k;
        }
    }
    [Benchmark]
    public static void TestFloatingPointDivision()
    {
        float i = 1;
        float j = 6;
        float k = 3;
        for (int x = 0; x < 1000000000; x++)
        {
            i = j / k;
        }
    }
    [Benchmark]
    public static void TestFloatingPointSquareRoot()
    {
        double x = 1;
        float y = 6;
        for (int x2 = 0; x2 < 1000000000; x2++)
        {
            x = Math.Sqrt(6);
        }
    }
    [Benchmark]
    public static void TestFloatingPointSine()
    {
        double x = 1;
        float y = 6;
        for (int x2 = 0; x2 < 1000000000; x2++)
        {
            x = Math.Sin(y);
        }
    }
    [Benchmark]
    public static void TestFloatingPointLogarithm()
    {
        double x = 1;
        float y = 6;
        for (int x2 = 0; x2 < 1000000000; x2++)
        {
            x = Math.Log(y);
        }
    }
    [Benchmark]
    public static void TestFloatingPointExp()
    {
        double x = 1;
        float y = 6;
        for (int x2 = 0; x2 < 1000000000; x2++)
        {
            x = Math.Exp(6);
        }
    }
    private static void TestStaticRoutine() {
    }
    private static void TestStaticRoutine2(int i)
    {
    }
    private static void TestStaticRoutine3(int i, int j)
    {
    }
    private static class TestStaticClass
    {
    }
