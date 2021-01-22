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
	int count = 0, lastStart = -1;   // next rev, I figure a way to get rid of these. 
     // this can't be a lambda, it has to be a real function
    IEnumerable<StartEnd> SplitSelection(StartLen sl)
     {  
    	yield return new StartEnd() {Pos = sl.Start, IsStart = true} ; 
    	yield return new StartEnd() {Pos = sl.Start+sl.Len -1 , IsStart = false} ; 
     }
	List<StartLen> startLen = new List<StartLen>();
	// we fill it with data for testing
	// pretending to be the real data
	startLen.Add(new StartLen() { Start=10, Len=10, UserId="abc123" });
	startLen.Add(new StartLen() { Start=15, Len=10, UserId="xyz321" });
	 var mostSelected  =  
		startLen.SelectMany<StartLen, StartEnd>(SplitSelection) 
			.OrderBy(se=>se.Pos) 
			.Select(se=>
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
						var seg = new Segment  
							{ Start = lastStart, End = se.Pos, Count = count }; 
						lastStart = -1; 
						return seg;
					} 
				} 
				// Garbage, cuz I need to return something 
				return new Segment { Start = 0, End = 0, Count = -1 };  
			}) 
		   .OrderByDescending(seg => seg.Count) 
		   .First(); 
		   
	// mostSelected  holds Start & End positions
    }
