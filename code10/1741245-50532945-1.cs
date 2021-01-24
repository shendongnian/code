    public class QueryParams {
    
        [FromQuery( Name = "$orderBy" )]
        public string OrderBy { get; set; }
    
        [FromQuery( Name = "$skip" )]
        public int? Skip { get; set; }
    
        [FromQuery( Name = "$top" )]
        public int? Take { get; set; }
    
        [FromQuery( Name = "$maxpagesize" )]
        public int? MaxPageSize { get; set; }
    
        [FromQuery( Name = "$count" )]
        public bool? IncludeCount { get; set; }
    }
