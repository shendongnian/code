     foreach(var group in groupedResult)
     {
         Console.WriteLine("Group: " + group.Key);
         foreach(var item in group)
         {
             Console.WriteLine("  Item: " + item);
         }
     }
