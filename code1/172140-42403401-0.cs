    class StringIndexable
    {
    //you could also have a constructor pass this in if you want.
           public readonly string[] possibleIndexes = { "index1", "index2","index3" };
        private string[] rowValues;
        public StringIndexable()
        {
            rowValues = new string[ColumnTitles.Length];
        }
        /// <summary>
        /// Will Throw an IndexOutofRange Exception if you mispell one of the above column titles
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string this [string index]
        {
            get { return getOurItem(index); }
            set { setOurItem(index, value); }
        }
        private string getOurItem(string index)
        {
            return rowValues[possibleIndexes.ToList().IndexOf(index.ToLower())];
        
        }
        private void setOurItem(string index, string value)
        {
            rowValues[possibleIndexes.ToList().IndexOf(index.ToLower())] = value;
        }
    }
