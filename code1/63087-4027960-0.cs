    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace LinqTest
    {
        class TestClass
        {
            public TestClass()
            {
                CreateDate = DateTime.Now;
            }
            public DateTime CreateDate;
        }
    
        class Program
        {
    
            static void Main(string[] args)
            {
                //Populate the test class
                List<TestClass> list = new List<TestClass>(1000);
                for (int i=0; i&lt;1000; i++)
                {
                    System.Threading.Thread.Sleep(20);
                    list.Add(new TestClass());
                    if(i%100==0)
                    { 
                        Console.WriteLine(i.ToString() +  " items added");
                    }
                }
                
                //now query for items 
                var newList = list.Where(o=> o.CreateDate.AddSeconds(5)> DateTime.Now);
                while (newList.Count() > 0)
                {
                    //Note - are actual count keeps decreasing.. showing our 'execute' is running every time we call count.
                    Console.WriteLine(newList.Count());
                    System.Threading.Thread.Sleep(500);
                }
            }
        }
    }
