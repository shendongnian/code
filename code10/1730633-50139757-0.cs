        static void Main(string[] args)
    {
        List<List<double>> lists = new List<List<double>>();
        lists.Add(new List<double> { 1, 2, 3 });
        lists.Add(new List<double> { 1, 2, 3 });
        lists.Add(new List<double> { 1, 2, 3 });
        lists.Add(new List<double> { 4, 5, 6 });
        lists.Add(new List<double> { 4, 5, 6 });
        lists.Add(new List<double> { 4, 5, 6 });
        lists.Add(new List<double> { 7, 8, 9 });
        lists.Add(new List<double> { 7, 8, 9 });
        lists.Add(new List<double> { 7, 8, 9 });
        lists.Add(new List<double> { 7, 8, 9 });
        List<List<List<double>>> sortedLists = new List<List<List<double>>>();
        for (int i = 0; i < lists.Count; i++)
        {
            bool found = false;
            if (!(sortedLists.Count == 0))
            {
                for (int j = 0; j < sortedLists.Count; j++)
                {
                    if (lists[i][0] == sortedLists[j][0][0] && lists[i][1] == sortedLists[j][0][1] && lists[i][2] == sortedLists[j][0][2])
                    {
                        found = true;
                        sortedLists[j].Add(lists[i]);
                        break;
                    }
                }
            }
            if (!found)
            {
                sortedLists.Add(new List<List<double>> { lists[i] });
            }
        }
    }
