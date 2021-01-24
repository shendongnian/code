       private static Dictionary<int, int> s_Solutions = new Dictionary<int, int>() {
         {0, int.MinValue},
         {1, 2},
         {2, 3},
         {3, 7},
         {4, 23},
         {5, 31},
         ... 
       };
       // O(1) solution - 31 items to scan only for the arbitrary N
       static int NotThatSlow(int N) {
         return s_Solutions
           .Where(pair => pair.Value < N)
           .OrderByDescending(pair => pair.Key)
           .Select(pair => pair.Value)
           .First(); 
       }
