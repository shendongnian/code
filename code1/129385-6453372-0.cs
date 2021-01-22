    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Diagnostics;
    namespace Tests
    {
        public class Dummy
        {
            public int Val;
            public Dummy(int val)
            {
                Val = val;
            }
        }
        public class WhereOrFindAll
        {
            const int ElCount = 20000000;
            const int FilterVal =1000;
            const int MaxVal = 2000;
            const bool CheckSum = true; // Checks sum of elements in list of resutls
            static List<Dummy> list = new List<Dummy>();
            public delegate void FuncToTest();
            public static long TestTicks(FuncToTest function, string msg)
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                function();
                watch.Stop();
                Console.Write("\r\n"+msg + "\t ticks: " + (watch.ElapsedTicks));
                return watch.ElapsedTicks;
            }
            static void Check(List<Dummy> list)
            {
                if (!CheckSum) return;
                Stopwatch watch = new Stopwatch();
                watch.Start();
                long res=0;
                int count = list.Count;
                for (int i = 0; i < count; i++)     res += list[i].Val;
                for (int i = 0; i < count; i++)     res -= (long)(list[i].Val * 0.3);
                watch.Stop();
                Console.Write("\r\n\nCheck sum: " + res.ToString() + "\t iteration ticks: " + watch.ElapsedTicks);
            }
            static void Check(IEnumerable<Dummy> ieNumerable)
            {
                if (!CheckSum) return;
                Stopwatch watch = new Stopwatch();
                watch.Start();
                IEnumerator<Dummy> ieNumerator = ieNumerable.GetEnumerator();
                long res = 0;
                while (ieNumerator.MoveNext())  res += ieNumerator.Current.Val;
                ieNumerator=ieNumerable.GetEnumerator();
                while (ieNumerator.MoveNext())  res -= (long)(ieNumerator.Current.Val * 0.3);
                watch.Stop();
                Console.Write("\r\n\nCheck sum: " + res.ToString() + "\t iteration ticks :" + watch.ElapsedTicks);
            }
            static void Generate()
            {
                if (list.Count > 0)
                    return;
                var rand = new Random();
                for (int i = 0; i < ElCount; i++)
                    list.Add(new Dummy(rand.Next(MaxVal)));
            }
            static void For()
            {
                List<Dummy> resList = new List<Dummy>();
                int count = list.Count;
                for (int i = 0; i < count; i++)
                {
                    if (list[i].Val < FilterVal)
                        resList.Add(list[i]);
                }      
                Check(resList);
            }
            static void Foreach()
            {
                List<Dummy> resList = new List<Dummy>();
                int count = list.Count;
                foreach (Dummy dummy in list)
                {
                    if (dummy.Val < FilterVal)
                        resList.Add(dummy);
                }
                Check(resList);
            }
            static void WhereToList()
            {
                List<Dummy> resList = list.Where(x => x.Val < FilterVal).ToList<Dummy>();
                Check(resList);
            }
            static void WhereIEnumerable()
            {
                Stopwatch watch = new Stopwatch();
                IEnumerable<Dummy> iEnumerable = list.Where(x => x.Val < FilterVal);
                Check(iEnumerable);
            }
            static void FindAll()
            {
                List<Dummy> resList = list.FindAll(x => x.Val < FilterVal);
                Check(resList);
            }
            public static void Run()
            {
                Generate();
                long[] ticks = { 0, 0, 0, 0, 0 };
                for (int i = 0; i < 10; i++)
                {
                    ticks[0] += TestTicks(For, "For \t\t");
                    ticks[1] += TestTicks(Foreach, "Foreach \t");
                    ticks[2] += TestTicks(WhereToList, "Where to list \t");
                    ticks[3] += TestTicks(WhereIEnumerable, "Where Ienum \t");
                    ticks[4] += TestTicks(FindAll, "FindAll \t");
                    Console.Write("\r\n---------------");
                }
                for (int i = 0; i < 5; i++)
                    Console.Write("\r\n"+ticks[i].ToString());
            }
        
        }
        class Program
        {
            static void Main(string[] args)
            {
                WhereOrFindAll.Run();
                Console.Read();
            }
        }
    }
