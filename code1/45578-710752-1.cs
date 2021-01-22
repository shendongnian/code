            static void Main(string[] args)
            {
                string[][] myList = new string[3][];
                myList[0] = new string[] { "1", "5", "3", "9" };
                myList[1] = new string[] { "2", "3" };
                myList[2] = new string[] { "93" };
    
                List<string> permutations = new List<string>(myList[0]);
    
                for (int i = 1; i < myList.Length; ++i)
                {
                    permutations = RecursiveAppend(permutations, myList[i]);
                }
    
                //at this point the permutations variable contains all permutations
    
            }
    
            static List<string> RecursiveAppend(List<string> priorPermutations, string[] additions)
            {
                List<string> newPermutationsResult = new List<string>();
                foreach (string priorPermutation in priorPermutations)
                {
                    foreach (string addition in additions)
                    {
                        newPermutationsResult.Add(priorPermutation + ":" + addition);
                    }
                }
                return newPermutationsResult;
            }
