            //track the type:nth element discard
            var dict = new Dictionary<EnumType, int?>();
            dict[EnumType.B] = 3;
            dict[EnumType.C] = 4;
            //groupby turns our list of items into two collections, depending on whether their type is b or c
            var x = items.GroupBy(g => new { g.Type })
              .Select(g => new   //now project a new collection 
                {
                    g.Key.Type,  //that has the type 
                    SumPriceWithoutNthElement = //and a sum
                        //the sum is calculated by reducing the list based on index position: in where(v,i), the i is the index of the item. 
                        //We drop every Nth one, N being determined by a dictioary lookup or 2 if the lookup is null
                        //we only want list items where (index%N != N-1) is true
                        g.Where((v, i) => (i % (dict[g.Key.Type]??2)) != ((dict[g.Key.Type] ?? 2) - 1))
                        .Sum(r => r.Price) //sum the price for the remaining
                }
            ).ToList(); //tolist may not be necessary, i just wanted to look at it
