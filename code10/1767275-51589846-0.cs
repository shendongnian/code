    public class DateRangeModel
    {
    	public DateTime From {get; set;}
    	public DateTime To   {get; set;}
    	
    	public IEnumerable<DateTime> DaysInRange {
    		get{
    			for(DateTime date = StartDate; date.Date <= EndDate.Date; date = date.AddDays(1))
    			{
    				yield date;
    			}
    		}
    	}
    
    	public DateRangeModel(string from, string to)
    	{
    		From = GetDate(from);
    		To = GetDate(to);
    	}
    	
    	private static DateTime GetDate(string string_date)
        {
            DateTime dateValue;
            if (DateTime.TryParse(string_date, out dateValue))
    			return dateValue;
            else
                throw new Exception("Unable to convert '{0}' to a date.", string_date);
            
        }
    }
    
    protected void Submit_click(object sender, EventArgs e)
    {
    
    	DateRangeModel dateRange = new DateRangeModel(txtstartdate.Text, txtenddate.Text);
    
    	OleDbConnection scn = new OleDbConnection();
    	scn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data   Source=/mysource;";
    
    	foreach(var dt in dateRange.DaysInRange)
    	{
    		OleDbCommand scmd = new OleDbCommand("Insert query", scn);
    		scmd.CommandType = CommandType.Text;
    		scmd.Parameters.Clear();
    		scmd.Parameters.AddWithValue("@date1", dt);
    		scmd.Parameters.AddWithValue("reason", txtreason);
    		//etc (finish your insert stmt here).
    	}  
    }
