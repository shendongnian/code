    Person p1 = new Person();
    Person p2 = new Person();
    bool b;
    Benchmark(() =>
    {
        b = (object)p1 == (object)p2; //960 ~ 1000ms
        b = object.ReferenceEquals(p1, p2); //~ 1250ms
        b = object.Equals(p1, p2); //2100ms
    
    }, 100000000);
     
    Person p1 = new Person();
    Person p2 = null;
    bool b;
    Benchmark(() =>
    {
        b = (object)p1 == (object)p2; //990 ~ 1000ms
        b = object.ReferenceEquals(p1, p2); // 1230 ~ 1260ms
        b = object.Equals(p1, p2); //1250 ~ 1300ms
    
    }, 100000000);
        
    Person p1 = null;
    Person p2 = null;
    bool b;
    Benchmark(() =>
    {
        b = (object)p1 == (object)p2; //960 ~ 1000ms
        b = object.ReferenceEquals(p1, p2); //1260 ~ 1270ms
        b = object.Equals(p1, p2); //1180 ~ 1220ms
    
    }, 100000000);
        
    Person p1 = new Person();
    Person p2 = p1;
    bool b;
    Benchmark(() =>
    {
        b = (object)p1 == (object)p2; //960 ~ 1000ms
        b = object.ReferenceEquals(p1, p2); //1260 ~ 1280ms
        b = object.Equals(p1, p2); //1150 ~ 1200ms
    
    }, 100000000);
