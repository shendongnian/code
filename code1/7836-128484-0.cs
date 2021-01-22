    class MyHashTable : System.Collections.Hashtable    
    {
        public MyHashTable(string [,] values)
        {
            for (int i = 0; i < (values.Length)/2; i++)
            {
                this.Add(values[i,0], values[i,1]);
            }
        }
    }
