    var numbers = GetNumbers(3797);  
    public static IEnumerable<int> GetNumbers(int val)
            {
                int ba = 1;
                int result = 1;
    
                while(result > 0)
                {
                    
                    ba *= 10;
                    result = val / ba;
                    if(result > 0)
                        yield return result;
                }
                
            }
