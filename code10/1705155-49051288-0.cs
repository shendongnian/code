    string previousLine;
    DateTime previousDt;
    var timeOutList = new List<Tuple<string, string>>();
    while ((line = file.ReadLine()) != null) {
      //regex parsing, cast to DateTime
      if ((previousDt - dt).TotalSeconds > 5)
      {
         timeOutList.Add(new Tuple<string, string>(previousLine, line));
      }
 
      previousLine = line;
      previousDt = dt;
    }
    //do something with the timeOutList like saving it to a file
