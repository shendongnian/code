    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    
    namespace stackoverflow
    {
        static class LinkedListPerformance
        {
            class Temp
            {
                public decimal A, B, C, D;
    
                public Temp(decimal a, decimal b, decimal c, decimal d)
                {
                    A = a; B = b; C = c; D = d;
                }
            }
    
    
    
            static readonly int start = 0;
            static readonly int end = 123456;
            static readonly IEnumerable<Temp> query = Enumerable.Range(start, end - start).Select(temp);
            
            static Temp temp(int i)
            {
                return new Temp(i, i, i, i);
            }
    
            static void StopAndPrint(this Stopwatch watch)
            {
                watch.Stop();
                Console.WriteLine(watch.Elapsed.TotalMilliseconds);
            }
    
            public static void AddFirst_List()
            {
                var list = new List<Temp>();
                var watch = Stopwatch.StartNew();
                
                for (var i = start; i < end; i++)
                    list.Insert(0, temp(i));
    
                watch.StopAndPrint();
            }
    
            public static void AddFirst_LinkedList()
            {
                var list = new LinkedList<Temp>();
                var watch = Stopwatch.StartNew();
    
                for (int i = start; i < end; i++)
                    list.AddFirst(temp(i));
    
                watch.StopAndPrint();
            }
    
            public static void AddLast_List()
            {
                var list = new List<Temp>();
                var watch = Stopwatch.StartNew();
    
                for (var i = start; i < end; i++)
                    list.Add(temp(i));
    
                watch.StopAndPrint();
            }
    
            public static void AddLast_LinkedList()
            {
                var list = new LinkedList<Temp>();
                var watch = Stopwatch.StartNew();
    
                for (int i = start; i < end; i++)
                    list.AddLast(temp(i));
    
                watch.StopAndPrint();
            }
    
            public static void Enumerate_List()
            {
                var list = new List<Temp>(query);
                var watch = Stopwatch.StartNew();
    
                foreach (var item in list)
                {
    
                }
    
                watch.StopAndPrint();
            }
    
            public static void Enumerate_LinkedList()
            {
                var list = new LinkedList<Temp>(query);
                var watch = Stopwatch.StartNew();
    
                foreach (var item in list)
                {
    
                }
    
                watch.StopAndPrint();
            }
    
            //for the fun of it, I tried to time inserting to the middle of 
            //linked list - this is by no means a realistic scenario! or may be 
            //these make sense if you assume you have the reference to middle node
            //insertion to the middle of list
            public static void AddMiddle_List()
            {
                var list = new List<Temp>();
                var watch = Stopwatch.StartNew();
    
                for (var i = start; i < end; i++)
                    list.Insert(list.Count / 2, temp(i));
    
                watch.StopAndPrint();
            }
            //insertion in linked list in such a fashion that 
            //it has the same effect as inserting into the middle of list
            public static void AddMiddle_LinkedList1()
            {
                var list = new LinkedList<Temp>();
                var watch = Stopwatch.StartNew();
    
                LinkedListNode<Temp> evenNode = null, oddNode = null;
                for (int i = start; i < end; i++)
                {
                    if (list.Count == 0)
                        oddNode = evenNode = list.AddLast(temp(i));
                    else
                        if (list.Count % 2 == 1)
                            oddNode = list.AddBefore(evenNode, temp(i));
                        else
                            evenNode = list.AddAfter(oddNode, temp(i));
                }
    
                watch.StopAndPrint();
            }
    
            //another hacky way
            public static void AddMiddle_LinkedList2()
            {
                var list = new LinkedList<Temp>();
                var watch = Stopwatch.StartNew();
    
                for (var i = start + 1; i < end; i += 2)
                    list.AddLast(temp(i));
                for (int i = end - 2; i >= 0; i -= 2)
                    list.AddLast(temp(i));
    
                watch.StopAndPrint();
            }
    
            //OP's original more sensible approach, but I tried to filter out
            //the intermediate iteration cost in finding the middle node.
            public static void AddMiddle_LinkedList3()
            {
                var list = new LinkedList<Temp>();
                var watch = Stopwatch.StartNew();
    
                for (var i = start; i < end; i++)
                {
                    if (list.Count == 0)
                        list.AddLast(temp(i));
                    else
                    {
                        watch.Stop();
                        var curNode = list.First;
                        for (var j = 0; j < list.Count / 2; j++)
                            curNode = curNode.Next;
                        watch.Start();
    
                        list.AddBefore(curNode, temp(i));
                    }
                }
    
                watch.StopAndPrint();
            }
        }
    }
