     List<object> list1 = new List<object>();
     List<object> list2 = new List<object>();
     List<object> list3 = new List<object>();
     List<KeyValuePair<int, object>> mergedList = new List<KeyValuePair<int, object>>();
     mergedList.AddRange(list1.Select(obj => new KeyValuePair<int, object>(1, obj)));
     mergedList.AddRange(list2.Select(obj => new KeyValuePair<int, object>(2, obj)));
     mergedList.AddRange(list3.Select(obj => new KeyValuePair<int, object>(3, obj)));
