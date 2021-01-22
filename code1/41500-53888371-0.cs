    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace dictionary
    {
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            var lstIntList = new List<object>();
            var lstStrings = new List<object>();
            var lstObjects = new List<object>();
            string s = "";
            lstIntList.Add(1);
            lstIntList.Add(2);
            lstIntList.Add(3);
            lstStrings.Add("a");
            lstStrings.Add("b");
            lstStrings.Add("c");
            dic.Add("Numbers", lstIntList);
            dic.Add("Letters", lstStrings);
            foreach (KeyValuePair<string, object> kvp in dic)
            {
                Console.WriteLine("{0}", kvp.Key);
                lstObjects = ((IEnumerable)kvp.Value).Cast<object>().ToList();
                foreach (var obj in lstObjects)
                   {s = obj.ToString(); Console.WriteLine(s);}
                Console.WriteLine("");
            }
            Console.WriteLine("");
            Console.WriteLine("press any key to exit");
            Console.ReadKey();
        }//end main
    }
    }
