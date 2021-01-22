using System;
using System.Diagnostics;
using System.Collections;
     namespace ArrayListBenchmark
     {
         class Program
         {
             static void Main(string[] args)
             {
                 Stopwatch sw = new Stopwatch();
                 const int arrayCount = 10000000;
                 ArrayList list = new ArrayList(arrayCount);
                 for (int i = 0; i < arrayCount; i++) list.Add("zzz " + i);
     
                 sw.Start();
                 DoesContainRev(list, "zzz");
                 sw.Stop();
                 Console.WriteLine(String.Format("1: {0}", sw.ElapsedMilliseconds));
                 sw.Reset();
     
                 sw.Start();
                 DoesContainRev1(list, "zzz");
                 sw.Stop();
                 Console.WriteLine(String.Format("2: {0}", sw.ElapsedMilliseconds));
                 sw.Reset();
     
                 sw.Start();
                 DoesContainFwd(list, "zzz");
                 sw.Stop();
                 Console.WriteLine(String.Format("3: {0}", sw.ElapsedMilliseconds));
                 sw.Reset();
     
                 sw.Start();
                 DoesContainFwd1(list, "zzz");
                 sw.Stop();
                 Console.WriteLine(String.Format("4: {0}", sw.ElapsedMilliseconds));
                 sw.Reset();
     
                 sw.Start();
                 list.Contains("zzz");
                 sw.Stop();
                 Console.WriteLine(String.Format("5: {0}", sw.ElapsedMilliseconds));
                 sw.Reset();
     
                 Console.ReadKey();
             }
             public static bool DoesContainRev(ArrayList list, object element)
             {
                 int count = list.Count;
                 for (int i = count - 1; i >= 0; i--)
                     if (element.Equals(list[i])) return true;
     
                 return false;
             }
             public static bool DoesContainFwd(ArrayList list, object element)
             {
                 int count = list.Count;
                 for (int i = 0; i < count; i++)
                     if (element.Equals(list[i])) return true;
     
                 return false;
             }
             public static bool DoesContainRev1(ArrayList list, object element)
             {
                 int count = list.Count;
                 for (int i = count - 1; i >= 0; i--)
                     if (list[i].Equals(element)) return true;
     
                 return false;
             }
             public static bool DoesContainFwd1(ArrayList list, object element)
             {
                 int count = list.Count;
                 for (int i = 0; i < count; i++)
                     if (list[i].Equals(element)) return true;
     
                 return false;
             }
         }
     }
     
