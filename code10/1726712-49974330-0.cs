    using System;
    using System.Data;
    using System.Xml;
    					
    public class Program
    {
    	public static void Main()
    	{
    		DataTable d = new DataTable();
    		d.Columns.Add("Foo", typeof(string));
    		DataRow row = d.NewRow();		
    		row["Foo"] = "Bar";
    		d.Rows.Add(row);
    		
    		Console.WriteLine((string)d.Rows[0]["Foo"]);
    		
    	}
    }
