      static Random random = new Random();
    
        // Note, max is exclusive here!
        public static List<int> GenerateRandom(int count, double min, double max)
        {
        
            if (max <= min || count < 0 || 
                    // max - min > 0 required to avoid overflow
                    (count > max - min && max - min > 0))
            {
                // need to use 64-bit to support big ranges (negative min, positive max)
                throw new ArgumentOutOfRangeException("Range " + min + " to " + max + 
                        " (" + ((Double)max - (Double)min) + " values), or count " + count + " is illegal");
            }
    
            // generate count random values.
            HashSet<int> candidates = new HashSet<int>();
    
            // start count values before max, and end at max
            for (double top = max - count; top < max; top++)
            {
                // May strike a duplicate.
                // Need to add +1 to make inclusive generator
                // +1 is safe even for MaxVal max value because top < max
                if (!candidates.Add(random.Next(min, top + 1))) {
                    // collision, add inclusive max.
                    // which could not possibly have been added before.
                    candidates.Add(top);
                }
            }
    
            // load them in to a list, to sort
            List<int> result = candidates.ToList();
    
            // shuffle the results because HashSet has messed
            // with the order, and the algorithm does not produce
            // random-ordered results (e.g. max-1 will never be the first value)
            for (int i = result.Count - 1; i > 0; i--)
            {  
                int k = random.Next(i + 1);  
                int tmp = result[k];  
                result[k] = result[i];  
                result[i] = tmp;  
            }  
            return result;
        }
    
        public static List<int> GenerateRandom(int count)
        {
            return GenerateRandom(count, 0, Double.MaxValue);
        }
