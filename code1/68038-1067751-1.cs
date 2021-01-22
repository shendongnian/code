     StringCollection parameterIds = new StringCollection();
     StringCollection parameterValues = new StringCollection();
     parameterIds.Add("someID");
     parameterValues.Add("someValue");
    
     var dataSource = parameterIds.Cast<string>()
         .SelectMany(itemOne => parameterValues
         .Cast<string>(), (itemOne, item2) => new { Row1 = itemOne, Row2 = item2 });
    
     repeater.DataSource = dataSource;
     repeater.DataBind();
