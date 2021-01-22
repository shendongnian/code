        /// <summary>
        /// Print All the Permutations.
        /// </summary>
        /// <param name="inputStr">input string</param>
        /// <param name="strLength">length of the string</param>
        /// <param name="outputStr">output string</param>
        private void PrintAllPermutations(string inputStr, int strLength,string outputStr, int NumberOfChars)
        {
            //Means you have completed a permutation.
            if (outputStr.Length == NumberOfChars)
            {
                Console.WriteLine(outputStr);                
                return;
            }
            //For loop is used to print permutations starting with every character. first print all the permutations starting with a,then b, etc.
            for(int i=0 ; i< strLength; i++)
            {
                // Recursive call : for a string abc = a + perm(bc). b+ perm(ac) etc.
                PrintAllPermutations(inputStr.Remove(i, 1), strLength - 1, outputStr + inputStr.Substring(i, 1), 4);
            }
        }        
