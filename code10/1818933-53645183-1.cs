     var lines = File.ReadAllLines(fileName);
     foreach (var line in lines) {
         //no error checking
         var indexString = line.Substring(column1Start, column1Length);
         var cartoon = line.Substring(column2Start, column2Length).TrimEnd();
         var numberString = line.Substring(column3Start);
         if (int.TryParse(indexString, out var index)) {
             //I have to parse the first number - otherwise there's nothing to index on
             if (!decimal.TryParse(numberString, out var number)){
                 number = 0.0M;
             }
             data.Add(index, (cartoon, number));
             if (index < indexMin) {
                 indexMin = index;
             }
             if (index > indexMax) {
                 indexMax = index;
             }
         }
     }
