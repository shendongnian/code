    //array to store max size of each column
    int[] sizes = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    foreach (var line in File.ReadLines(filePath)) {
        var tmp = line.Trim(); // remove leading and trailing whitespace
        tmp = tmp.Remove(tmp.Length - 2, 2); // remove closing ) and , or ;
        tmp = tmp.Remove(0, 1); // remove opening (   
        // split by comma                 
        var words = Regex.Split(tmp, @",(?=(?:[^\']*\'[^\']*\')*[^\']*$)");
        if (words.Length == 18) {
            for (int i = 0; i < words.Length; i++) {
                var word = words[i].Trim(); // remove whitespace
                sizes[i] = sizes[i] < word.Length ? word.Length : sizes[i];
            }
        }
        else throw new Exception("Invalid number of columns");
    }
