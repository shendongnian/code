    List<DateTimeInterval> dtiList = new List<DateTimeInterval>();
    DateTimeInterval dtInterval = new DateTimeInterval(new DateTime(2018, 09, 10), new DateTime(2018, 09, 20));
                
    dtiList.Add(new DateTimeInterval(new DateTime(2018, 06, 12), new DateTime(2018, 7, 1)));
    dtiList.Add(new DateTimeInterval(new DateTime(2018, 09, 05), new DateTime(2018, 09, 15)));
    dtiList.Add(new DateTimeInterval(new DateTime(2018, 09, 12), new DateTime(2018, 09, 20)));
    dtiList.Add(new DateTimeInterval(new DateTime(2018, 09, 11), new DateTime(2018, 09, 15)));
    dtiList.Add(new DateTimeInterval(new DateTime(2018, 09, 5), new DateTime(2018, 09, 9)));
                
    foreach(var dti in dtiList)
    {                          
       Console.WriteLine(DateTimeInterval.Intersect(dtInterval, dti));
    }
