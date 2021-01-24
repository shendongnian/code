    public void WriteToCSV(List<mifid2_vpc_monitored_detail_view> list, string filename)
    	{
    	string attachment = "attachment; filename=" + filename;
    
    	HttpContext.Current.Response.Clear();
    	HttpContext.Current.Response.ClearHeaders();
    	HttpContext.Current.Response.ClearContent();
    	HttpContext.Current.Response.AddHeader("content-disposition", attachment);
    	HttpContext.Current.Response.ContentType = "text/csv";
    	HttpContext.Current.Response.AddHeader("Pragma", "public");
    	HttpContext.Current.Response.ContentEncoding = Encoding.UTF8;
    
    
    	WriteHeader();
    	StringBuilder csv = new StringBuilder();
    
    	string _uti, _counterparty;
    	DateTime _maturity, _date;
    	decimal _volume;
    
    	var newLine = "";
    
    	for (int i = 0; i < list.Count; i++)
    	{
    		if (list[i].uti_cd == null) _uti = "-"; else _uti = list[i].uti_cd;
    		if (list[i].namecounterparty == null) _counterparty = "-"; else _counterparty = list[i].namecounterparty;
    		if (list[i].maturity == null) _maturity = DateTime.MinValue.Date; else _maturity = list[i].maturity;
    		if (list[i].contract_volume == 0) _volume = 0; else _volume = list[i].contract_volume;
    		if (list[i].evaluation_date == null) _date = DateTime.MinValue.Date; else _date = list[i].evaluation_date;
    
    		newLine = string.Format("{0},{1},{2},{3},{4}", _uti, _counterparty, _maturity, _volume, _date);
    		csv.AppendLine(newLine);
    	}
    
    
    	MemoryStream mstream = new MemoryStream();
    	StreamWriter sw = new StreamWriter(mstream);
    	sw.Write(csv);
    	sw.Flush();
    	sw.Close();
    	byte[] byteArray = mstream.ToArray();
    	mstream.Flush();
    	mstream.Close();
    	HttpContext.Current.Response.BinaryWrite(byteArray);
    	HttpContext.Current.Response.End();
    }
