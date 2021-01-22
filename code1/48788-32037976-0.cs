    class ClassicPermutationProblem
    {
        ClassicPermutationProblem() { }
     
        private static void PopulatePosition<T>(List<List<T>> finalList, List<T> list, List<T> temp, int position)
        {
             foreach (T element in list)
             {
                 List<T> currentTemp = temp.ToList();
                 if (!currentTemp.Contains(element))
                    currentTemp.Add(element);
                 else
                    continue;
     
                 if (position == list.Count)
                    finalList.Add(currentTemp);
                 else
                    PopulatePosition(finalList, list, currentTemp, position + 1);
            }
        }
     
        public static List<List<int>> GetPermutations(List<int> list)
        {
            List<List<int>> results = new List<List<int>>();
            PopulatePosition(results, list, new List<int>(), 1);
            return results;
         }
    }
     
    static void Main(string[] args)
    {
        List<List<int>> results = ClassicPermutationProblem.GetPermutations(new List<int>() { 1, 2, 3 });
    }
