     public static void MergeLists() {
          var listOne=new List<List1> {
            new List1 {ID=1, Person="Alice"},
            new List1 {ID=2, Person="Bob"},
            new List1 {ID=3, Person="Carol"},
            new List1 {ID=4, Person="Dave"},
            new List1 {ID=5, Person="Dave2"},
            new List1 {ID=6, Person="Dave3"},
          };
          var listTwo=new List<List2> {
            new List2 {ID=1, Value=15},
            new List2 {ID=1, Value=19},
            new List2 {ID=2, Value=5},
            new List2 {ID=2, Value=7},
            new List2 {ID=2, Value=20},
            new List2 {ID=4, Value=16}
          };
    
          var listTwoWithAddedItems=listOne.AddMissingItems(listTwo, (item1, item2) => item1.ID==item2.ID,
                                                        item2 => new List2 { ID=item2.ID, Value=-1 }).ToList();//For this value, you can put whatever default value you want to set for the missing items.
    
          Console.Read();
        }
    
         public static class AmbyExtends {
        
            public static List<Target> AddMissingItems<Source, Target>(this IEnumerable<Source> source, List<Target> target, Func<Source, Target, bool> selector, Func<Source, Target> creator) {
              foreach(var item in source) {
                if(!target.Any(x=>selector(item,x))) {
                  target.Add(creator(item));
                }         
              }
              return target;
            }
          }
