        static ICollection<string> result;
        public static ICollection<string> GetAllPermutations(string str, int outputLength)
        {
            result = new List<string>();
            MakePermutations(str.ToCharArray(), string.Empty, outputLength);
            return result;
        }
        private static void MakePermutations(
           char[] possibleArray,//all chars extracted from input
           string permutation,
           int outputLength//the length of output)
        {
             if (permutation.Length < outputLength)
             {
                 for (int i = 0; i < possibleArray.Length; i++)
                 {
                     var tempList = possibleArray.ToList<char>();
                     tempList.RemoveAt(i);
                     MakePermutations(tempList.ToArray(), 
                          string.Concat(permutation, possibleArray[i]), outputLength);
                 }
             }
             else if (!result.Contains(permutation))
                result.Add(permutation);
        }
