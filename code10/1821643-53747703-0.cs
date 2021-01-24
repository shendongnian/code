    var a = Enumerable.Union(list1, list2);
    IEnumerable<BaseClass> b = Enumerable.Union(list1, list2); 
    var c = Enumerable.Union(list1.Cast<BaseClass>(), list2);
    var d = Enumerable.Union(list1, list2.Cast<BaseClass>());
    var e = Enumerable.Union(list1.Cast<BaseClass>(), list2.Cast<BaseClass>());
