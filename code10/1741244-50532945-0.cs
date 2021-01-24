    public class QueryParams {
    
        [FromQuery( "$orderBy" )]
        public string OrderBy { get; set; }
    
        [FromQuery( "$skip" )]
        public int? Skip { get; set; }
    
        [FromQuery( "$top" )]
        public int? Take { get; set; }
    
        [FromQuery( "$maxpagesize" )]
        public int? MaxPageSize { get; set; }
    
        [FromQuery( "$count" )]
        public bool? IncludeCount { get; set; }
    }
