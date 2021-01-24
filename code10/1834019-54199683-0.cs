    List<A> result = inputList                       // For each item in inputList
      .Select(item => new A() {                      // Create A instance
         myDict = new Dictionary<string, string>() { // Assign myDict within A by a dictionary
           {"elem1", item.elem1},                    // Which has 4 items
           {"elem2", item.elem2},
           {"elem3", item.elem3},
           {"elem4", item.elem4}, 
         }
       })
      .ToList();                                       // Materialize as a List<A>
 
