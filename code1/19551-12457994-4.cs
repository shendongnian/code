    class HashTableProgram
    {
        static void Main(string[] args)
        {
            Hashtable ht = new Hashtable();
            ht.Add(1, "One");
            ht.Add(2, "Two");
            ht.Add(3, "Three");
            foreach (DictionaryEntry de in ht)
            {
                int Key = (int)de.Key; //Casting
                string value = de.Value.ToString(); //Casting
                Console.WriteLine(Key + " " + value);
            }
        }
    }
