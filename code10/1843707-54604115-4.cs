    List<string> list1 = new List<string> { "0186264-9-2019-019", "0186264-9-2019-020" };
    List<string> list2 = new List<string> { "0186264-9-2019-020" , "0186264-9-2019-019" };
       
    if (list1.Except(list2).Any())
    {
     // All list 1 values present in list 2
    }
    else
    {
       // All list 1 values not present in list 2
    }
