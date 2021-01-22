    // Existing data structure
    class StartLen
    {
        public int Start {get; set;}
        public int Len   {get; set;}
        public string UserId {get; set;}
    }
    
    // Needed data struct
    class StartEnd
    {
        public int Pos {get; set;}
        public bool IsStart {get; set;}
    }
    
    
    List<StartLen> startLen = new List<StartLen>() //  etc
    
    var startEnd = 
        startLen.SelectMany(sl => 
             { 
                yield return new StartEnd() {Pos = sl.Start, IsStart = true;} ;
                yield return new StartEnd() {Pos = sl.Start+sl.Len -1 , IsStart = false;} ;
             })
            .OrderBy(se=>se.Pos);
