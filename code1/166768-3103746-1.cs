    Regex r1 = new Regex(@"([a-z])([A-Z])");
    Regex r2 = new Regex(@"([A-Z]+)([A-Z][a-z])");
    
    NewString = r1.Replace( InputString , "$1 $2");
    NewString = r2.Replace( NewString , "$1 $2");
