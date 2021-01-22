    class Data {
         Dictionary<string, Dictionary<string, string>> keywords;
         DatesClass dates;
         .......
        
    }
    
    class DatesClass
    {
        string startDate;
        string endDate;
        bool? useDates
    
    }
    var mydata = JsonConvert.DeserializeObject<Data>(jsonstring);
