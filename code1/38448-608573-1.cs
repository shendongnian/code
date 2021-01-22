    // a struct
    struct Interval {
       int From { get; set; }
       int To { get; set; }
    }
    
    // create a list of structs
    List<Interval> intervals = new List<Interval>();
    // add a struct to the list
    intervals.Add(new Interval());
    
    // try to set the values of the struct
    Interval[0].From = 10;
    Interval[0].To = 20;
