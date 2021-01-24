     var lineCount = File.ReadLines(@"YourFile").Count();
       for(int i = 0; i < lineCount; i+=2)
           {
              var twoLines = File.ReadLines(@"YourFile").Skip(i).Take(2);
           }
