            System.Collections.Hashtable ht = new System.Collections.Hashtable();
            ht.Add("test1", "test2");
            ht.Add("test3", "test4");
            List<string> keys = new List<string>();
            foreach (System.Collections.DictionaryEntry de in ht)
                keys.Add(de.Key.ToString());
            foreach(string key in keys)
            {
                ht[key] = DateTime.Now;
                Console.WriteLine(ht[key]);
            }
