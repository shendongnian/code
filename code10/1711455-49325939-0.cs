    List<string> listFrom = new List<string>(); //Contains a list of strings
    List<string> listTo = new List<string>(); //Contains a list of strings
    string lineStart = listFrom.Except(listTo).SingleOrDefault();
    string lineEnd = listFrom.Except(listTo).SingleOrDefault();
    int startLineIndex = listFrom.IndexOf(lineStart);            //Error on this line
    Console.WriteLine("Index of Start: " + startLineIndex);
