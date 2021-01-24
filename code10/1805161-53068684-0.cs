     var listOfLists = new List<List<double>>
     {
         new List<double> {1.0, 2.0, 3.0},
         new List<double> {3.14, 42.0}
     };
     var buffer = new StringBuilder();
     var first = true;
     foreach (var list in listOfLists)
     {
         foreach (var item in list)
         {
             if (!first)
             {
                 buffer.Append(',');
             }
             first = false;
             buffer.Append(item.ToString());
         }
     }
     var concatenated = buffer.ToString();
