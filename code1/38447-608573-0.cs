    // a struct
    struct Interval {
       int From { get; set; }
       int To { get; set; }
    }
    
    // create an array of structs
    Interval[] intervals = new Interval[10];
    
    // try to set the values of a struct
    Interval[0].From = 10;
    Interval[0].To = 20;
