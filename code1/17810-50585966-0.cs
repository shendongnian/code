    public class PopularNumber
        {
            private Int32[] numbers = {5, 4, 3, 32, 6, 6, 3, 3, 2, 2, 31, 1, 32, 4, 3, 4, 5, 6};
    
            public PopularNumber()
            {
                Dictionary<Int32,Int32> bucket = new Dictionary<Int32,Int32>();
                Int32 maxInt = Int32.MinValue;
                Int32 maxCount = 0;
                Int32 count;
    
                foreach (var i in numbers)
                {
                    if (bucket.TryGetValue(i, out count))
                    {
                        count++;
                        bucket[i] = count;
                    }
                    else
                    {
                        count = 1;
                        bucket.Add(i,count);
                    }
    
                    if (count >= maxCount)
                    {
                        maxInt = i;
                        maxCount = count;
                    }
    
                }
    
                Console.WriteLine("{0},{1}",maxCount, maxInt);
    
            }
        }
