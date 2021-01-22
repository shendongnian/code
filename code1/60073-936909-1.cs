    using System;
    using System.Diagnostics;
    public static class test{
    public static void Main(string[] args){
        MyTest();
        PowTest();
    }
    static void PowTest(){
        var sw = Stopwatch.StartNew();
        double res = 0;
        for (int i = 0; i < 333333333; i++){
            res = Math.Pow(i,30); //pow(i,30)
        }
        Console.WriteLine("Math.Pow: " + sw.ElapsedMilliseconds + " ms:  " + res);
    }
    static void MyTest(){
        var sw = Stopwatch.StartNew();
        double res = 0;
        for (int i = 0; i < 333333333; i++){
            res = MyPow(i,30);
        }
        Console.WriteLine("MyPow: " + sw.ElapsedMilliseconds + " ms:  " + res);
    }
    static double MyPow(double num, int exp)
    {
        double result = 1.0;
        while (exp > 0)
        {
            if (exp % 2 == 1)
                result *= num;
            exp >>= 1;
            num *= num;
        }
        return result;
    }
    }
