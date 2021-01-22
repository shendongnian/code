            static IEnumerable<int> GetFactors(int n)
            {
                Debug.Assert(n >= 1);
                var pairList = from i in Enumerable.Range(1, (int)(Math.Round(Math.Sqrt(n) + 1)))
                        where n % i == 0
                        select new { A = i, B = n / i };
    
                foreach(var pair in pairList)
                {
                    yield return pair.A;
                    yield return pair.B;
                }
    
                
            }
