    var checks = List<Point>();
    
    checks.Add(new Point(x+1,y));
    checks.Add(new Point(x-1,y));
    checks.Add(new Point(x,y+1));
    checks.Add(new Point(x,y-1));
    
    foreach(var check in checks)
       //If Bounds check
       //do what you need to do 
