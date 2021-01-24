    class YourType {
        // properties that match your columns
        public string Name {get;set;}
        public double Attendance {get;set;}
    }
    ...
    var row = con.QuerySingleOrDefault<YourType>(
        "Select top 1 * from Table1 Order by First_name");
