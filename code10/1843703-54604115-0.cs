    List<string> list1 = new List<string> { "0186264-9-2019-019", "0186264-9-2019-020" };
    
    List<string> list2 = new List<string> { "0186264-9-2019-020" };
    
    List<string> Common = list1.Where(c => list2.Contains(c)).ToList();
