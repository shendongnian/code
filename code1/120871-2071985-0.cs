    List<T> list12 = dict1["key1"]["key2"];
---
    List<int> list1 = new List<int>();
    list1.Add(1);
    list1.Add(2);
    
    Dictionary<string, List<int>> innerDict = new Dictionary<string, List<int>>();
    innerDict.Add("inner", list1);
    
    Dictionary<string, Dictionary<string, List<int>>> dict1 =
        new Dictionary<string, Dictionary<string, List<int>>>();
    dict1.Add("outer", innerDict);
    List<int> list2 = dict1["outer"]["inner"];
