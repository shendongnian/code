    Regex r= new Regex(@"^(?<version>(\d\.?)*), *Type: *(?<dataType>.*), *Value: (?<dataValue>.*)$");
    
    IEnumerable<MyData> ParseData(IEnumerable<string> lines)
    {
        foreach(var line in lines)
        {
            var match = r.Matches.SingleOrDefault();
            if (match != null)
            {
              //you might need to do some parsing here, just illustrating the concept
              yield return new MyData(match["version"], match["dataType"], match["dataValue"]);
            }
            //probably add else with logging/exception
        }
    }
