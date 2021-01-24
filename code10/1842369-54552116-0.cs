        var list1 = new List<object>() { 1, 2, 3 };
                var list2 = new List<object>() { 4, 5, 6 };
                var list3 = new List<object>() { 3, 1, 2 };
        
                List<List<object>> mainList = new List<List<object>>() { list1, list2, list3 };
                
    var distinctlist = mainList.Select(o => { var t = o.OrderBy(x=>x).Select(i => i.ToString()); return new {Key= string.Join("", t),List=o}; }).
                                    GroupBy(o=>o.Key).
                                    Select(o=>o.FirstOrDefault()).
                                    Select(o=>o.List);
