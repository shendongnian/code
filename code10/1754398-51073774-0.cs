    using System;
    using System.Data;
    using System.Linq;
					
    public class Program
    {
	    public static void Main()
    	{
	    	var table1 = GetEmptyTable();
		    table1.Rows.Add(1, "Old Value", false);
    		table1.Rows.Add(2, "Untouched Value", false);
	    	
		    var table2 = GetEmptyTable();
    		table2.Rows.Add(1, "New Value", false);
	    	table2.Rows.Add(3, "Unused Value", false);
		
		    Console.WriteLine("Before...");
    		Console.WriteLine(PrintTable(table1));
		
	    	var matched = table1.Select()
    			.Join(table2.Select(), t1 => (int)t1["A"], t2 => (int)t2["A"], (t1, t2) 
    => new
    			{
	    			DestinationRow = t1,
		    		SourceRow = t2
    			});
    		foreach (var match in matched)
	    	{
		    	match.DestinationRow["B"] = match.SourceRow["B"];
    			match.DestinationRow["C"] = true;
    		}
		
    		Console.WriteLine("After...");
    		Console.WriteLine(PrintTable(table1));
    	}
	
    	private static DataTable GetEmptyTable()
    	{
	    	var table = new DataTable();
    		table.Columns.Add("A", typeof(int));
    		table.Columns.Add("B", typeof(string));
    		table.Columns.Add("C", typeof(bool));
    		return table;
    	}
						  
    	private static string PrintTable(DataTable table)
    	{
    		return string.Join(Environment.NewLine, table.Select().Select(x => "[" + 
    string.Join(", ", x.ItemArray) + "]"));
    	}
    }
