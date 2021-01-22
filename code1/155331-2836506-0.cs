        List<string> listA = new List<string>();
        List<string> listB = new List<string>();
        listA.Add("A");
        listA.Add("B");
        listA.Add("C");
        listA.Add("D");
        listB.Add("B");
        listB.Add("D");
        for (int i = listA.Count - 1; i >= 0; --i)
        {
            int matchingIndex = listB.LastIndexOf(listA[i]);
            if (matchingIndex != -1)
                listB.RemoveAt(matchingIndex);
        }
