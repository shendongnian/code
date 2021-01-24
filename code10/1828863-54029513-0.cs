    public List<IWebElement> GetAllRows(){
    List<IWebElement> allRows = new List<IWebElement>();
    foreach(var row in GetAllCrashRows())
    {
    //here u gonna get each row with data inside your rows that you already have using nested element (row)
     allrows.Add(row.FindEleemnts("//div[starts-with(@class,'col h-col')]"));
    }
    return allRows;
    }
    //Then u need another foresch loop to get text with data for each inner row
    public List<string> GetRowsData(){
    List<string> allRowsData = new List<string>();
    foreach(var data in GetAllRows())
    {
     allRowsData.Add(data.Text)
    }
    return allRowsData;
    }
