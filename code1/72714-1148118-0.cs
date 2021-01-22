            Dictionary<String, Object> dictionary = new Dictionary<String, Object>();
            for (int i = 0; i <= 10; i++)
            {
                //create name
                string name = String.Format("s{0}", i);
                //check name
                if (dictionary.ContainsKey(name))
                {
                    dictionary[name] = i.ToString();
                }
                else
                {
                    dictionary.Add(name, i.ToString());
                }
            }
            //Simple test
            foreach (KeyValuePair<String, Object> kvp in dictionary)
            {
                Console.WriteLine(String.Format("Key: {0} - Value: {1}", kvp.Key, kvp.Value));
            }
