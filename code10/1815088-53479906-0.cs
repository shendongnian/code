    using System.Linq;
    ...
    double[] circs = ...
    int[] loc = circs
      .Select((value, index) => new { // for each item we store
         value = value,               //   its value
         index = index                //   and original index
       })
      .OrderBy(pair => pair.value)  // Order by values
      .Select(pair => pair.index)   // By return original index
      .ToArray();
