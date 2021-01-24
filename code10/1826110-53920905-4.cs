    startnum = int.Parse(startnumbers);
    
    endnum = int.Parse(endnumbers);
    
    string route = "1.";
    
    if (startletters == endletters && startnum > endnum)
    {
       for (int count = 0; startnum < endnum; startnum++)
       {
          if (startname != endname)
          {
             count++;
             string tempRoute = string.Format("Board the {0} line, go {1} stops toward {2}",startletters,count, endname);
             route = route + " " + tempRoute;
          }
       }
    }
