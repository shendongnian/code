    void Main()
    {
    	
    	 string s = string.Join(";", Enumerable.Range(65, 26).Select(c => (char)c));
                s = s.Insert(3, ";;;");
    
                string o = "";
    
                Stopwatch sw = new Stopwatch();
    
                sw.Start();
                for (int i = 1; i <= 1000000; i++) {
                    o = s.Split(';', 21);
                }
                sw.Stop();
                Console.WriteLine("Item directly selected: " + sw.ElapsedMilliseconds);
    
    
                sw.Restart();
                for (int i = 1; i <= 1000000; i++) {
                    o = s.MyExtension(';', 21);
                }
                sw.Stop();
                Console.WriteLine("Item directly selected by MyExtension: " + sw.ElapsedMilliseconds);
    
                sw.Restart();
                for (int i = 1; i <= 1000000; i++) {
                    o = s.Split(';')[21];
                }
                sw.Stop();
                Console.WriteLine("Item from split array:  " + sw.ElapsedMilliseconds + "\r\n");
    
    
                Console.WriteLine(s);
                Console.WriteLine(o);
    	
    }
    
    public static class MyExtensions
    {
        /// <summary>
        /// Get the nth item from a delimited string.
        /// </summary>
        /// <param name="s">The string to retrieve a delimited item from.</param>
        /// <param name="delimiter">The character used as the item delimiter.</param>
        /// <param name="n">Zero-based index of item to return.</param>
        /// <returns>The nth item or an empty string.</returns>
        public static string Split(this string s, char delimiter, int n)
        {
            int pos = pos = s.IndexOf(delimiter);
            if (n == 0 || pos < 0)
            { return (pos >= 0) ? s.Substring(0, pos) : s; }
            int nDelims = 1;
            while (nDelims < n && pos >= 0)
            {
                pos = s.IndexOf(delimiter, pos + 1);
                nDelims++;
            }
            string result = "";
            if (pos >= 0)
            {
                int nextDelim = s.IndexOf(delimiter, pos + 1);
                result = (nextDelim < 0) ? s.Substring(pos + 1) : s.Substring(pos + 1, nextDelim - pos - 1);
            }
            return result;
        }
		
		public static string MyExtension(this string s, char delimiter, int n)
		{
			var begin = n== 0 ? 0 : Westwind.Utilities.StringUtils.IndexOfNth(s, delimiter, n);
            if (begin == -1)
                return null;
			var end = s.IndexOf(delimiter, begin + 1);
			if (end == -1 ) end = s.Length;
			//var end = Westwind.Utilities.StringUtils.IndexOfNth(s, delimiter, n + 1);
			var result = s.Substring(begin +1, end - begin -1 );
			
			return result;
		}
    }
