    [HttpGet] 
    public IDictionary<int, Site> GetSites([FromQuery] int? source) {
        if (source.HasValue) {
            // get specific 
        } else {
            // get all
        }
    }
