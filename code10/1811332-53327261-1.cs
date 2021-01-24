    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Newtonsoft.Json;
    
    namespace ConsoleApp2
    {
    class Program
    {
        class WahEvah
        {
            public int first;
            public string one;
            public string two;
            public string last;
        }
        static void Main(string[] args)
        {
            List<string> myString = "1,a,b,C1,,#2,d,e,C2,,#3,f,g,C3,,#4,h,i,C4,,#".Split('#').ToList();
            List<List<string>> myString2 = myString.Select(x => x.Split(',').ToList()).ToList();
            List<WahEvah> l = new List<WahEvah>();
            int counter = 0;
            for (int i = 0; i < myString2.Count - 1; i++)
            {
                WahEvah wd = NewMethod(myString2[i], counter);
                l.Add(wd);
            }
            string json = JsonConvert.SerializeObject(l, Formatting.Indented);
            Console.Write(json);
            Console.ReadLine();
        }
        private static WahEvah NewMethod(List<string> myString, int counter)
        {
            counter = 0;
            WahEvah w = null; w = new WahEvah();
            foreach (string s2 in myString)
            {
                if (counter == 0)
                {
                    w.first = Convert.ToInt32(s2.Trim()); counter++; continue;
                }
                if (counter == 1)
                {
                    w.one = s2.Trim(); counter++; continue;
                }
                if (counter == 2)
                {
                    w.two = s2.Trim(); counter++; continue;
                }
                if (counter == 3)
                {
                    w.last = s2.Trim(); counter++; continue;
                }
            }
            return w;
        }
    }
}
