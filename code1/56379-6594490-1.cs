    //Strict type declaration
            Dictionary<int,string> dictionary= new Dictionary<int, string>();
            dictionary.Add(1, "One");
            dictionary.Add(2, "Two");
            dictionary.Add(3, "Three");
            dictionary.Add(4, "Four");
            dictionary.Add(5, "Five");
            dictionary.Add(6, "Six");
            dictionary.Add(7, "Seven");
            dictionary.Add(8, "Eight");
            dictionary.Add(9, "Nine");
            //dictionary.Add("Ten", 10);// error as only key, value pair of type int, string can be added
            //for i=0, key doesn't  exist error
            for (int i = 1; i <= dictionary.Count; i++)
            {
                //Can be accessed through indexers
                Console.WriteLine(dictionary[i]);
            }
            //Error : The given key was not present in the dictionary.
            //Console.WriteLine(dictionary[10]);
