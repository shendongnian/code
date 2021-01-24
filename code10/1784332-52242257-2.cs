    // Initially project each element in the list to an element that 
    // has also the info in which list this item is contained.
    var list1 = List1.Select(x => new {Data = x, List = 1});
    var list2 = List2.Select(x => new {Data = x, List = 2});
    var result = list1.Concat(list2)
                .GroupBy(x => new {x.Data.Batch, x.Data.Material})
                .Select(gr =>
                {
                    var itemsInGroup = gr.Count();
                    if (itemsInGroup == 1)
                    {
                        var onlyItemInGroup = gr.First();
                        if (onlyItemInGroup.List == 1)
                        {
                            return onlyItemInGroup.Data;
                        }
                        // Item came from the second list. So multiply it's quantity by -1.
                        onlyItemInGroup.Data.QTY *= -1;
                        return onlyItemInGroup.Data;
                    }
                   
                    // Since for each item in list 1 there is at most one item in the list2
                    // and vice versa itemsInGroup now is 2 and it is safe to use First as below
                    // to grab the items.
                    var itemFromFirstList = gr.First(x => x.List == 1);
                    var itemFromSecondList = gr.First(x => x.List == 2);
                    return new List_Data
                    {
                        Material = gr.Key.Material,
                        Batch = gr.Key.Batch,
                        QTY = itemFromFirstList.Data.QTY - itemFromSecondList.Data.QTY
                    };
                }).ToList();
