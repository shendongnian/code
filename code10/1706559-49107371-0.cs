    if(list2.Any(item => item.Contains("Dt.")))
    {
        int idx = list2.IndexOf("Dt.");
        if(list3.ElementAt(idx).Contains("25.04.2017"))
        {
            var newList = list.ElementAt(idx);
        }
    }
