        static void Main(string[] args)
        {
            System.Collections.Hashtable htable = new System.Collections.Hashtable();
            htable.Add("MyName", "WindyCityEagle");
            htable.Add("MyAddress", "Here");
            htable.Add(new Guid(), "That Was My Guid");
            int loopCount = 0;
            foreach (string s in htable.Keys)
            {
                Console.WriteLine(loopCount++.ToString());
                Console.WriteLine(htable[s]);
            }
        }
