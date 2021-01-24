      static void Main(string[] args)
        {
            public string GetDataValue(string data, string index)
        {
            string value = data.Substring(data.IndexOf(index) + index.Length - 1 );
            if (value.Contains("|"))
            {
                value = value.Remove(value.IndexOf("|"));
            }
            return value;
        }
