        static IEnumerable<string> GenerateTest(int minChars, int maxChars, int setSize) {
            string letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string numbers = "0123456789";            
            Random rnd = new Random();
            int maxStrLength = maxChars-minChars;
            float probablityOfLetter = 0.0f;
            float probablityInc = 1.0f / setSize;
            for (int i = 0; i < setSize; i++) {
                probablityOfLetter = probablityOfLetter + probablityInc;
                int length = minChars + rnd.Next() % maxStrLength;
                char[] str = new char[length];
                for (int w = 0; w < length; w++) {
                    if (probablityOfLetter < rnd.NextDouble())
                        str[w] = letters[rnd.Next() % letters.Length];
                    else 
                        str[w] = numbers[rnd.Next() % numbers.Length];                    
                }
                yield return new string(str);
            }
        }
