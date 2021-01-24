    var list1 = new List<int>{1,2,2};
    var list2 = new List<int>{1,1,2};
    var list1Distinct = list1.Distinct();
    var list2Distinct = list1.Distinct();
    var allDistinctValues = list1.Intersect(list2);
    bool listsEqual = true;
    
    foreach(int i in allDistinctValues)
    {
        int list1Count=0;
        int list2Count=0;
        list1Count = list1.Count(val => val == i);
        list2Count = list2.Count(val => val == i);
        if(list1Count != list2Count)
        {
            listsEqual = false;
        }
    }
    
    if(!listsEqual)
    {
        //List item counts not the same
    }
