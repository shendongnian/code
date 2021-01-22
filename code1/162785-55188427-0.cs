        public List<string> SplitArray(string item, int size)
        {
            if (item.Length <= size) return new List<string> { item };
            var temp = new List<string> { item.Substring(0,size) };
            temp.AddRange(SplitArray(item.Substring(size), size));
            return temp;
        }
