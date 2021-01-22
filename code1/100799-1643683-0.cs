        var myDic = new Dictionary<int, Dictionary<int, string>>();
        foreach(var item in myDic)
            foreach (var subItem in item.Value)
            {
                Display(
                    subItem.Key,    // int
                    subItem.Value); // User
            }
