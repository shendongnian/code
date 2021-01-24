    // Initially project each element in the list to an element that 
    // has also the info in which list this item is contained.
    var list1 = List1.Select(x => new {Data = x, List = 1});
    var list2 = List2.Select(x => new {Data = x, List = 2});
    // The concat the lists and group them based on the Key that is 
    // formed by the Batch and Material
    var result = list1.Concat(list2)
                      .GroupBy(x => new {x.Data.Batch, x.Data.Material})
                      .Select(gr =>
                      {
                          var itemsInGroup = gr.Count();
                          if (itemsInGroup == 1 
                              && gr.First().List == 1)
                          {
                              var item = gr.First();
                              return item.Data;
                          }
      
                          if (itemsInGroup == 1 
                              && gr.First().List == 2)
                          {
                              var item = gr.First();
                              item.Data.QTY *= -1;
                              return item.Data;
                          }
                          var itemInFirstList = gr.First(x => x.List == 1);
                          var itemInSecondList = gr.First(x => x.List == 2);
                          return new List_Data
                          {
                              Material = gr.Key.Material,
                              Batch = gr.Key.Batch,
                              QTY = itemInFirstList.Data.QTY -itemInSecondList.Data.QTY
                          };
                      }).ToList();
