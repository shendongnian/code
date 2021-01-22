    List<DataRow> searchRecords = new List<DataRow>();
    string searchDateOnHour = DateTime.Now.ToString("dd/MM/yyyy HH");
    foreach (DataRow item in table.Rows)
    {
        DateTime recordDate;
        DateTime.TryParse(item["comDate"].ToString(), out recordDate);
        string recordDateHour = recordDate.ToString("dd/MM/yyyy HH");        
        if (searchDateOnHour == recordDateHour)
            searchRecords.Add(item);            
    }
