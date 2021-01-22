    public int? BestTime { get; set; }
    public int? WorstTime { get; set; }
    public int? AvgTime { get; set; }
    public int TimeoutReachedCount { get; set; }
    public int AllRunCount { get; set; }
    public string Str => $@"
       Ran {AllRunCount} times; 
       Reached timeout {TimeoutReachedCount} times; 
       Best time = {(BestTime.HasValue ? BestTime.ToString() : "N/A")}; 
       Worst time = {(WorstTime.HasValue ? WorstTime.ToString() : "N/A")}; 
       Average time = {(AvgTime.HasValue ? AvgTime.ToString() :"N/A")};"
           .Replace(Environment.NewLine, "");
