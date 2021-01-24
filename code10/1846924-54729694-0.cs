     static void Main(string[] args)
            {
                Console.Write("Enter a word or phrase : ");
                string input = Console.ReadLine();
    
                char[] listOfVowels = new char[] { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
    
                int vowel = 0;
                int sameVowel = 0;
                List<char> vowers = new List<char>();
    
                for (int i = 0; i < input.Length; i++)
                {
                    if (listOfVowels.Contains(input[i]))
                    {
                        Console.WriteLine(input[i]);
                        vowel++;
    
                        vowers.Add(input[i]);
    
                        //if(vowers.Contains(input[i]))
                        //{
                        //    sameVowel++;
                        //}
    
                    }
                }
    
                sameVowel = vowers.GroupBy(_ => _).Where(_ => _.Count() > 1).Sum(_ => _.Count());
                Console.WriteLine(string.Format("The total number of vowel are : {0}", vowel));
                Console.WriteLine(string.Format("The total of the same number of vowel are : {0}", sameVowel));
                Console.ReadLine();
            }
