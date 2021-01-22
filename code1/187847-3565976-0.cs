    string[] test = "P,MV,A1ZWR,MAV#(X,,), PV,MOV#(X,12,33),LO".Split(',');
    bool insideElement = false;
    string insideElementResult = "";
    List<string> result = new List<string>();
    foreach (string s in test)
    {
        //Determine context:
        if (s.IndexOf("(") > -1)
            insideElement = true;
        //Determine where to add my nice string
        if (!insideElement)
            result.Add(s);
        else
            insideElementResult += s;
        //Determine if contact has ended:
        if (s.IndexOf(")") > -1)
        {
            insideElement = false;
            result.Add(insideElementResult);
            insideElementResult = null;
        }
        else if (insideElement)
        {
            insideElementResult += ",";
        }
    }
