       public static IEnumerable<string> Chunkify(this string input, int size)
            {
                if(size < 1)
                    throw new ArgumentException("size must be greater than 0");
    
                return input.ToCharArray()
                    .ToObservable()
                    .Buffer(size)            
                    .Select(x => new string(x.ToArray()))
                    .ToEnumerable();
            }
