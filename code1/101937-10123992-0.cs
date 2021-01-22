    LINQ is not just for the developers who used to write queries for databases but also for the Functional Programmers. So do not worry if you are not very comfortable with SQL kind of queries, we have a very nice option called “Lambda Expression”. Here I am going to demonstrate the scenario for both the options with a small example. This example has an array of integers and I am only retrieving the even numbers using the power of LINQ. Here we go
 
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
