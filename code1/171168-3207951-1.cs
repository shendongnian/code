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
    
    class Segment
    {
        public int Start { get; set; }
        public int End { get; set; }
        public int Count { get; set; }
    }    
    List<StartLen> startLen = new List<StartLen>() //  etc
    
    int count = 0; lastStart = -1;   // next rev, I figure a way to get rid of these.
    var mostSelected  = 
        startLen.SelectMany(sl => 
             { 
                yield return new StartEnd() {Pos = sl.Start, IsStart = true;} ;
                yield return new StartEnd() {Pos = sl.Start+sl.Len -1 , IsStart = false;} ;
             })
            .OrderBy(se=>se.Pos)   // sorted list of StartEnd objects here.
            .Select(se =>
            {
                if (se.IsStart)
                {
                    lastStart = se.Pos;
                    count++;
                }
                else
                {
                    count--;
                    if (lastStart > 0)
                    {
                        lastStart = -1;
                        yield return new Segment 
                            { Start = lastStart, End = se.Pos, Count = cout };
                    }
                }
                 // Garbage, cuz I need to return something
                yield return new Segment { Start = 0, End = 0, Count = -1 }; 
            })
           .OrderByDescending(seg => seg.Count)
           .First();
