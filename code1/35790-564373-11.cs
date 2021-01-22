    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    public class MyData
    {
        public int A { get; set; }
        public string B { get; set; }
        public DateTime C { get; set; }
        public decimal D { get; set; }
        public string E { get; set; }
        public int F { get; set; }
    }
    
    static class Program
    {
        static void RunTest(List<MyData> data, string caption)
        {
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
            GC.WaitForFullGCComplete();
            Stopwatch watch = Stopwatch.StartNew();
            for (int i = 0; i < 500; i++)
            {
                data.ToDataTable();
            }
            watch.Stop();
            Console.WriteLine(caption + "\t" + watch.ElapsedMilliseconds);
        }
        static void Main()
        {
            List<MyData> foos = new List<MyData>();
            for (int i = 0 ; i < 5000 ; i++ ){
                foos.Add(new MyData
                { // just gibberish...
                    A = i,
                    B = i.ToString(),
                    C = DateTime.Now.AddSeconds(i),
                    D = i,
                    E = "hello",
                    F = i * 2
                });
            }
            RunTest(foos, "Vanilla");
            Hyper.ComponentModel.HyperTypeDescriptionProvider.Add(
                typeof(MyData));
            RunTest(foos, "Hyper");
            Console.ReadLine(); // return to exit        
        }
    }
