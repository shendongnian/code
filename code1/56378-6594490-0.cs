           //No strict type declaration
            Hashtable hash = new Hashtable();
            hash.Add(1, "One");
            hash.Add(2, "Two");
            hash.Add(3, "Three");
            hash.Add(4, "Four");
            hash.Add(5, "Five"); 
            hash.Add(6, "Six");
            hash.Add(7, "Seven");
            hash.Add(8, "Eight");
            hash.Add(9, "Nine");
            hash.Add("Ten", 10);// No error as no strict type
    
            for(int i=0;i<=hash.Count;i++)//=>No error for index 0
            {
                //Can be accessed through indexers
                Console.WriteLine(hash[i]);
            }
            Console.WriteLine(hash["Ten"]);//=> No error in Has Table
