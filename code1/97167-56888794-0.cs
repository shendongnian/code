    var existingOrNewObject = MyData.Where(myCondition)
           .Concat(Enumerable.Range(1,1).Select(_ => {
               //Create my object...
               return item;
           })).Take(1).First();
