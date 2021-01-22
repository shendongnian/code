    List<char> levelChars = new List<char>();
    levelChars.AddRange("+%@&~".ToCharArray());
    List<string> names = new List<string>();
    names.AddRange(new[]{"~user1", "~user84",  "@user3", "&user8", "+user39", "user002", "user2838", "%user29"});
    names.Sort((x,y) =>
                   {
                       int xLevel = levelChars.IndexOf(x[0]);
                       int yLevel = levelChars.IndexOf(y[0]);
    
                       if (xLevel != yLevel)
                       {
                           // if xLevel is higher; x should come before y
                           return xLevel > yLevel ? -1 : 1;
                       }
                       
                       // x and y have the same level; regular string comparison
                       // will do the job
                       return x.CompareTo(y);                       
                   });
