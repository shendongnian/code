    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ListArrayLinkedListTests
    {
        class Program
        {
            private static string resultsTemplate = "Test from 1 up to {0}. Time test is {1} min {2} sec {3} millisec";
    
            static void Main(string[] args)
            {
                int maxInteger = 56000000;
    
                var ArrFill = Array_Fill(maxInteger);
    
                var LATE = List_AddToEnd(maxInteger);
    
                Console.WriteLine("Test1. Fill Array with Some size is faster than AddToEnd into the List in {0} times\r\n\r\n", LATE / ArrFill);
                
                var LLATE = LinkedList_AddToEnd(maxInteger);
    
                Console.WriteLine("Test2. AddToEnd of List is faster than AddToEnd of LinkedList in {0} times\r\n\r\n", LLATE / ArrFill);
    
                var ATATE = ArrayTest_AddToEnd(maxInteger/100) * 100;
    
                Console.WriteLine("Test3. AddToEnd of List is faster than to do resize of array every time in {0} times\r\n\r\n", ATATE / ArrFill);
                
    
                maxInteger = 100000;
    
                var AnotherLT = ListTest_addIntoCenter(maxInteger);
    
                var AnotherLLT = LinkedList_addIntoCenter(maxInteger);
    
                Console.WriteLine("Test4. LinkedList faster than List if we need to add some item into the center of list in {0} times\r\n\r\n", AnotherLT / AnotherLLT);
    
                Console.ReadKey();
            }
    
    
            private static int List_AddToEnd(int maxInteger)
            {
                List<int> Lst = new List<int>();
                int StartTime, EndTime;
                string result;
    
                Console.WriteLine("Starting ListTest_AddToEnd test...");
    
                StartTime = DateTime.Now.Minute * 60 * 1000 + DateTime.Now.Second * 1000 + DateTime.Now.Millisecond;
    
                for (int i = 0; i < maxInteger; i++)
                {
                    Lst.Add(i);
                }
    
                EndTime = DateTime.Now.Minute * 60 * 1000 + DateTime.Now.Second * 1000 + DateTime.Now.Millisecond;
    
                var time = TimeSpan.FromMilliseconds(EndTime - StartTime);
                result = string.Format(resultsTemplate, maxInteger, time.Minutes, time.Seconds, time.Milliseconds);
    
                Console.WriteLine(result + "\r\n");
    
                return (EndTime - StartTime);
            }
    
            private static int LinkedList_AddToEnd(int maxInteger)
            {
                LinkedList<int> Lst = new LinkedList<int>();
                int StartTime, EndTime;
                string result;
    
                Console.WriteLine("Starting LinkedList_AddToEnd test...");
    
                StartTime = DateTime.Now.Minute * 60 * 1000 + DateTime.Now.Second * 1000 + DateTime.Now.Millisecond;
    
                for (int i = 0; i < maxInteger; i++)
                {
                    Lst.AddLast(i);
                }
    
                EndTime = DateTime.Now.Minute * 60 * 1000 + DateTime.Now.Second * 1000 + DateTime.Now.Millisecond;
    
                var time = TimeSpan.FromMilliseconds(EndTime - StartTime);
                result = string.Format(resultsTemplate, maxInteger, time.Minutes, time.Seconds, time.Milliseconds);
    
                Console.WriteLine(result + "\r\n");
    
                return (EndTime - StartTime);
            }
    
            private static int Array_Fill(int maxInteger)
            {
                int[] arr = new int[maxInteger];
                int StartTime, EndTime;
                string result;
    
                Console.WriteLine("Starting Array_Fill test...");
                StartTime = DateTime.Now.Minute * 60 * 1000 + DateTime.Now.Second * 1000 + DateTime.Now.Millisecond;
    
                for (int i = 0; i < maxInteger; i++)
                {
                    arr[i] = i;
                }
    
                EndTime = DateTime.Now.Minute * 60 * 1000 + DateTime.Now.Second * 1000 + DateTime.Now.Millisecond;
    
                var time = TimeSpan.FromMilliseconds(EndTime - StartTime);
                result = string.Format(resultsTemplate, maxInteger, time.Minutes, time.Seconds, time.Milliseconds);
    
                Console.WriteLine(result + "\r\n");
    
                return (EndTime - StartTime);
            }
    
            private static int ArrayTest_AddToEnd(int maxInteger)
            {
                int[] arr = new int[1];
                int StartTime, EndTime;
                string result;
    
                Console.WriteLine("Starting IntData_ArrayTestResizeEveryLoop test...");
                StartTime = DateTime.Now.Minute * 60 * 1000 + DateTime.Now.Second * 1000 + DateTime.Now.Millisecond;
    
                for (int i = 0; i < maxInteger; i++)
                {
                    Array.Resize<int>(ref arr, arr.Length + 1);
                    arr[i] = i;
                }
    
                EndTime = DateTime.Now.Minute * 60 * 1000 + DateTime.Now.Second * 1000 + DateTime.Now.Millisecond;
    
                var time = TimeSpan.FromMilliseconds(EndTime - StartTime);
                result = string.Format(resultsTemplate, maxInteger, time.Minutes, time.Seconds, time.Milliseconds);
    
                Console.WriteLine(result + "\r\n");
    
                return (EndTime - StartTime);
            }
    
    
    
            private static int ListTest_addIntoCenter(int maxInteger)
            {
                List<int> Lst = new List<int>();
                int StartTime, EndTime;
                string result;
    
                Console.WriteLine("Starting IntData_ListTest test...");
    
                StartTime = DateTime.Now.Minute * 60 * 1000 + DateTime.Now.Second * 1000 + DateTime.Now.Millisecond;
    
                Lst.Add(0);
                Lst.Add(1);
    
                for (int i = 1; i < maxInteger; i++)
                {
                    Lst.Insert(2, i);
                }
    
                EndTime = DateTime.Now.Minute * 60 * 1000 + DateTime.Now.Second * 1000 + DateTime.Now.Millisecond;
    
                var time = TimeSpan.FromMilliseconds(EndTime - StartTime);
                result = string.Format(resultsTemplate, maxInteger, time.Minutes, time.Seconds, time.Milliseconds);
    
                Console.WriteLine(result + "\r\n");
    
                return (EndTime - StartTime);
            }
    
            private static int LinkedList_addIntoCenter(int maxInteger)
            {
                LinkedList<int> Lst = new LinkedList<int>();
                int StartTime, EndTime;
                string result;
    
                Console.WriteLine("Starting IntData_LinkedListTest test...");
    
                StartTime = DateTime.Now.Minute * 60 * 1000 + DateTime.Now.Second * 1000 + DateTime.Now.Millisecond;
    
                Lst.AddLast(1);
                Lst.AddLast(2);
    
                var temp = Lst.Find(2);
    
                for (int i = 2; i < maxInteger; i++)
                {
                    Lst.AddAfter(temp, i);
                }
    
                EndTime = DateTime.Now.Minute * 60 * 1000 + DateTime.Now.Second * 1000 + DateTime.Now.Millisecond;
    
                var time = TimeSpan.FromMilliseconds(EndTime - StartTime);
                result = string.Format(resultsTemplate, maxInteger, time.Minutes, time.Seconds, time.Milliseconds);
    
                Console.WriteLine(result + "\r\n");
    
                return (EndTime - StartTime);
            }
        }
    }
