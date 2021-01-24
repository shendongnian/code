       var list1 = new List<int>() {1, 2, 3};
       var list2 = new List<int>() {4, 5, 6};
        for (int i = list1.Count - 1; i >= 0; i--)
        {
            list2.Add(list1[i]);
            list1.Remove(list1[i]);
            if (list2.Count == 5)
            {
                break;
            }
        }
