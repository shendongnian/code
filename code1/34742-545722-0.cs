    static void Main() {
        List<List<int>> outerList = new List<List<int>>
        {   new List<int>(){1, 2, 3, 4, 5},
            new List<int>(){0, 1},
            new List<int>(){6,3},
            new List<int>(){1,3,5}
        };
        int[] result = new int[outerList.Count];
        Recurse(result, 0, outerList);
    }
    static void Recurse<TList>(int[] selected, int index,
        IEnumerable<TList> remaining) where TList : IEnumerable<int> {
        IEnumerable<int> nextList = remaining.FirstOrDefault();
        if (nextList == null) {
            StringBuilder sb = new StringBuilder();
            foreach (int i in selected) {
                sb.Append(i).Append(',');
            }
            if (sb.Length > 0) sb.Length--;
            Console.WriteLine(sb);
        } else {
            foreach (int i in nextList) {
                selected[index] = i;
                Recurse(selected, index + 1, remaining.Skip(1));
            }
        }
    }
