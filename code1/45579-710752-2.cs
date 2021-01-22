    static void Main(string[] args)
            {
                string[][] myList = new string[3][];
                myList[0] = new string[] { "1", "5", "3", "9" };
                myList[1] = new string[] { "2", "3" };
                myList[2] = new string[] { "93" };
    
                List<List<string>> permutations = new List<List<string>>();
    
                foreach (string init in myList[0])
                {
                    List<string> temp = new List<string>();
                    temp.Add(init);
                    permutations.Add(temp);
                }
    
                for (int i = 1; i < myList.Length; ++i)
                {
                    permutations = RecursiveAppend(permutations, myList[i]);
                }
    
                //at this point the permutations variable contains all permutations
    
                foreach (List<string> list in permutations)
                {
                    foreach (string item in list)
                    {
                        Console.Write(item + ":");
                    }
                    Console.WriteLine();
                }
    
            }
    
            static List<List<string>> RecursiveAppend(List<List<string>> priorPermutations, string[] additions)
            {
                List<List<string>> newPermutationsResult = new List<List<string>>();
                foreach (List<string> priorPermutation in priorPermutations)
                {
                    foreach (string addition in additions)
                    {
                        List<string> priorWithAddition = new List<string>(priorPermutation);
                        priorWithAddition.Add(addition);
                        newPermutationsResult.Add(priorWithAddition);
                    }
                }
                return newPermutationsResult;
            }
