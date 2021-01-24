    // Given initialized DataTable table;
    // Given public int IntProperty {get; set;} in public class MyObject    
    table.Rows.Select((row) => 
	{
		if(int.TryParse(row["stringValue"], out int intValue)){
			return new MyObject 
		    {
		    	IntProperty = intValue
			};
		}
		else {
			//do error handling
		}
	});
