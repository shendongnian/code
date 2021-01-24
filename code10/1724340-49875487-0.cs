    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Program
    {
      // Text as member here
      private static readonly string Text = "My data Statistics:\n" +
                                            "=============================================================\n" +
                                            "Bla bla                                           : 120\n" +
                                            "Bla bla bla bla                                   : 1\n" +
                                            "Number of files                                   : 1\n" +
                                            "Size                                              : 1\n" +
                                            "Total                                             : 1\n" + "\n";
 
      // Define how to now when a table starts and when it ends
      // Table starts when line is "My data Statistics:"
      private static readonly string TableStartMarker = "My data Statistics:";
      // Table ends when line is empty??? Not specified in question
      private static readonly string TableEndMarker = "";
      public static void Main()
      {
        //  Split text by \n to get lines
        var lines = new List<string>(Text.Split('\n'));
        // Find last line where content is the TableStartMarker (My data statistics... 
        var lastTableStart = lines.FindIndex(x => x == TableStartMarker);
        //Iterate over all lines starting from last table header
        foreach (var line in lines.Skip(lastTableStart))
        {
          // if line is empty -> table has endend
          if (line == TableEndMarker)
            return;
        
          //now we have content -> split by :
          var split = line.Split(':');
          if (split.Length < 2)
            continue;
 
          //remove whitespaces and there you go: key and value
          var key = split[0].TrimEnd();
          var value = split[1].TrimStart();
          Console.WriteLine(string.Format("Key: {0}, Value: {1}", key, value));
        }
      }
    }
