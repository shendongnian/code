            char stringSplit = '/';
            char keySplit = ' ';
            Dictionary<string,string[]> dictionary = new Dictionary<string, string[]>(1000);
            using(StreamReader sr = new StreamReader(@"c:\somefile.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    int keyIndex = line.IndexOf(keySplit);
                    string key = line.Substring(0, keyIndex);
                    string[] values = line.Substring(keyIndex + 1).Split(stringSplit);
                    dictionary.Add(key,values);
                }
            }
