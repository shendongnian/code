            IList<string> ilist = new List<string>();
            ilist.Add("B");
            ilist.Add("A");
            ilist.Add("C");
            Console.WriteLine("IList");
            foreach (string val in ilist)
                Console.WriteLine(val);
            Console.WriteLine();
            
            List<string> list = (List<string>)ilist;
            list.Sort();
            Console.WriteLine("List");
            foreach (string val in list)
                Console.WriteLine(val);
            Console.WriteLine();
            list = null;
            Console.WriteLine("IList again");
            foreach (string val in ilist)
                Console.WriteLine(val);
            Console.WriteLine();
