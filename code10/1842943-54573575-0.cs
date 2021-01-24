    public struct Person
    {
        public string name1;
        public string name2;
        public string merge()
        {
            string retval = "";
            int length = name1.Length;
            if (length < name2.Length)
                length = name2.Length;
            for(int i = 0; i < length; i++)
            {
                if (name1.Length > i)
                    retval += name1[i];
                if (name2.Length > i)
                    retval += name2[i];
            }
            return retval;
        }
    }
