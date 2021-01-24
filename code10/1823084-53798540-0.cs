        public static IEnumerable<string> SplitGroup(this string input, char delimiter)
        {
            var fields = input.Split(delimiter);
            var items = new List<string>();
            var enumerator = fields.GetEnumerator();
            
            //this will handle no commas, and not and even number of pairs
            while (enumerator.MoveNext())
            {
                var first = enumerator.Current;
                var hasNext = enumerator.MoveNext();
                var second = hasNext ? enumerator.Current : "";
    
                items.Add(String.Format("{0}{1}{2}", first, hasNext ? "," : "", second));
            }
    
            return items;
        }
