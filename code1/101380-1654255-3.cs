    DateTime date = DateTime.Now;
    List<MyDateTime> dates = new List<MyDateTime>();
    
    for (int i = 0; i < HISTORY_LENGTH; i++)
    {
        dates.Add(new MyDateTime(date.AddDays(-i)));
    }
    
    DropDownList.DataSource = dates;
    DropDownList.DataBind();
