    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Query;
    using System.Xml.XLinq;
    using System.Data.DLinq;
    namespace LINQConsoleApplication1
    {
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrInt = {1,2,3,4,5,6,7,8,9,10};
            #region Place to change
            //Language Integrated Query
            var aa = from s in arrInt
                     where s % 2 == 0
                     select s;
            #endregion
            foreach (var item in aa)
            {
                Console.WriteLine("{0}", item);
            }
            Console.ReadKey();
        }
    }
    }
