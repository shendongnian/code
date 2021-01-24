    public static void Main()
    {
        var jObject = JObject.Parse(jsonString);  
        var assignments = JsonConvert.DeserilizeObject<Assignment[]>(lp_ask["assignments"].ToString());
        var assignment = assignments.OrderByDescending(i => i.hours_logged).FirstOrDefault();
    }
    private class Assignment
    {
        public double hours_logged { get; set; }
        public int person_id { get; set; }
    }
    
