    using System;
    using System.Collections.Generic;
    
    class Program
    {
        static void Main()
        {
            List<int> list = new List<int> { 1, 2, 3 };
    
            List<int> newList = list.FindAll(delegate(int arg)
                               {
                                   return arg> 2;
                               });
        }
    }
