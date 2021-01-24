    using System;
    using System.Data;
    using System.Xml;
					
    public class Program
    {
	
	
	public static void Main()
	{
		var dt = CreateDataTable();
		
		foreach(DataRow row in dt.Rows)
		{
			UpdateTable(Convert.ToInt32(row["BatchNum"]), Convert.ToInt32(row["QTY"]));		
		}
		
	}
	
	public static void UpdateTable(int batchNum, int qty)
	{
		string sql = "update invoice set qty = "+qty+" where batchnum = " + batchNum ;
		Console.WriteLine(sql);
	}
					   
					   
	public static DataTable CreateDataTable()
	{
		DataTable dt = new DataTable();
		dt.Columns.Add(new DataColumn("BatchNum"));
		dt.Columns.Add(new DataColumn("QTY"));
		
		var row1 = dt.NewRow();
		var row2 = dt.NewRow();
		
		row1["BatchNum"] = 1;
		row1["QTY"] = 10;
		row2["BatchNum"] = 2;
		row2["QTY"] = 20;
		
		dt.Rows.Add(row1);
		dt.Rows.Add(row2);
		
		return dt;
	}
	 
}
