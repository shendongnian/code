    int? myNull = null;
    var clicks =
      from c in Clicks 
      select new mydata 
      {  
        date = c.ClickDate,
        click = c.ID,
        sale = c.ID + myNull
        lead = c.ID + myNull
      }; 
