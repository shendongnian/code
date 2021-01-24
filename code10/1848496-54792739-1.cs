    public void DataLoad1()
    {
    	var rowDT = data.GetListData();
    	
    	// loop data
    	foreach (DataRow row in rowDT.Rows)
    	{
    		var str = row.Select(o => o.ToString()).ToList();
    
    		_listView.Items.Add(new {
    			Checked = false,
    			DocNo   = str[0],
    			QtyReq  = str[1],
    			Price   = help.ThousandSeparator(str[2]),
    			Date    = help.ConvertDate(str[3]),
    			Status  = help.ConvertStatus(str[4]),
    			Confirm = help.ConvertConfirmed(str[5])
    		});
    	}
    }
