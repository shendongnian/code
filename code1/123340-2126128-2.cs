    var mostPopular = (from name in arrName.Cast<string>()
                       group name by name into g
                       orderby g.Count() descending
                       select g.Key).FirstOrDefault();
    
    Console.Write("Most popular value: {0}", mostPopular ?? "None");
