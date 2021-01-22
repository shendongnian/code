        public static int FindFirstInteger(this IEnumerable<char> array)
        {
            bool foundInteger = false;
            var ints = new List<char>();
            
            foreach (var c in array)
            {
                if(char.IsNumber(c))
                {
                    foundInteger = true;
                    ints.Add(c);
                }
                else
                {
                    if(foundInteger)
                    {
                        break;
                    }
                }
            }
            string s = string.Empty;
            ints.ForEach(i => s += i.ToString());
            return int.Parse(s);
        }
