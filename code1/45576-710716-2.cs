        static List<string> foo(int a, List<Array> x)
        {
            List<string> retval= new List<string>();
            if (a == x.Count)
            {
                retval.Add("");
                return retval;
            }
            foreach (Object y in x[a])
            {
                foreach (string x2 in foo(a + 1, x))
                {
                    retval.Add(y.ToString() + " " + x2.ToString());
                }
                
            }
            return retval;
        }
        static void Main(string[] args)
        {
            List<Array> myList = new List<Array>();
            myList.Add(new string[0]);
            myList.Add(new string[0]);
            myList.Add(new string[0]);
            myList[0] = new string[]{ "1", "5", "3", "9" };
            myList[1] = new string[] { "2", "3" };
            myList[2] = new string[] { "93" };
            foreach (string x in foo(0, myList))
            {
                Console.WriteLine(x);
            }
            
            Console.ReadKey();
        }
