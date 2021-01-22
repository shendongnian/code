      var keys = new List<string> { "Kalu", "Kishan", "Gourav" };
            var values = new List<string> { "Singh", "Paneri", "Jain" };
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            for (int i = 0; i < keys.Count; i++)
            {
               
                dictionary.Add(keys[i].ToString(), values[i].ToString());
            }
            foreach (var data in dictionary)
            {
                Console.WriteLine("{0} {1}", data.Key, data.Value);
            }
            Console.ReadLine();
