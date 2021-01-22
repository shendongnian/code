    using System;
    using System.Data;
    using System.Xml;
    using System.Linq;
    using System.Collections.Generic;
    using System.Data.DataSetExtensions;
    					
    public class Program
    {
    	private static DataTable GetDelta(DataTable table1, DataTable table2)
    	{
    		// Modified2 : row1 keys match rowOther keys AND row1 does not match row2:
    		IEnumerable<DataRow> modified2 = (
    			from row1 in table1.AsEnumerable()
    			from row2 in table2.AsEnumerable()
    			where table1.PrimaryKey.Aggregate(true, (boolAggregate, keycol) => boolAggregate & row1[keycol].Equals(row2[keycol.Ordinal]))
    				  && !row1.ItemArray.SequenceEqual(row2.ItemArray)
    			select row2);
    		
    		// Modified1 :
    		IEnumerable<DataRow> modified1 = (
    			from row1 in table1.AsEnumerable()
    			from row2 in table2.AsEnumerable()
    			where table1.PrimaryKey.Aggregate(true, (boolAggregate, keycol) => boolAggregate & row1[keycol].Equals(row2[keycol.Ordinal]))
    				  && !row1.ItemArray.SequenceEqual(row2.ItemArray)
    			select row1);
    		
    		// Added : row2 not in table1 AND row2 not in modified2
    		IEnumerable<DataRow> added = table2.AsEnumerable().Except(modified2, DataRowComparer.Default).Except(table1.AsEnumerable(), DataRowComparer.Default);
    		
    		// Deleted : row1 not in row2 AND row1 not in modified1
    		IEnumerable<DataRow> deleted = table1.AsEnumerable().Except(modified1, DataRowComparer.Default).Except(table2.AsEnumerable(), DataRowComparer.Default);
    		
    		
    		Console.WriteLine();
    		Console.WriteLine("modified count =" + modified1.Count());
    		Console.WriteLine("added count =" + added.Count());
    		Console.WriteLine("deleted count =" + deleted.Count());
    		
    		DataTable deltas = table1.Clone();
    		
    		foreach (DataRow row in modified2)
    		{
    			// Match the unmodified version of the row via the PrimaryKey
    			DataRow matchIn1 = modified1.Where(row1 =>  table1.PrimaryKey.Aggregate(true, (boolAggregate, keycol) => boolAggregate & row1[keycol].Equals(row[keycol.Ordinal]))).First();
    			DataRow newRow = deltas.NewRow();
    		
    			// Set the row with the original values
    			foreach(DataColumn dc in deltas.Columns)
    				newRow[dc.ColumnName] = matchIn1[dc.ColumnName];
    			deltas.Rows.Add(newRow);
    			newRow.AcceptChanges();
    		
    			// Set the modified values
    			foreach (DataColumn dc in deltas.Columns)
    				newRow[dc.ColumnName] = row[dc.ColumnName];
    			// At this point newRow.DataRowState should be : Modified
    		}
    		
    		foreach (DataRow row in added)
    		{
    			DataRow newRow = deltas.NewRow();
    			foreach (DataColumn dc in deltas.Columns)
    				newRow[dc.ColumnName] = row[dc.ColumnName];
    			deltas.Rows.Add(newRow);
    			// At this point newRow.DataRowState should be : Added
    		}
    		
    		
    		foreach (DataRow row in deleted)
    		{
    			DataRow newRow = deltas.NewRow();
    			foreach (DataColumn dc in deltas.Columns)
    				newRow[dc.ColumnName] = row[dc.ColumnName];
    			deltas.Rows.Add(newRow);
    			newRow.AcceptChanges();
    			newRow.Delete();
    			// At this point newRow.DataRowState should be : Deleted
    		}
    		
    		return deltas;
    	}
    	
    	private static void DemonstrateGetDelta()
    	{
    		DataTable table1 = new DataTable("Items");
    	
    		// Add columns
    		DataColumn column1 = new DataColumn("id1", typeof(System.Int32));
    		DataColumn column2 = new DataColumn("id2", typeof(System.Int32));
    		DataColumn column3 = new DataColumn("item", typeof(System.Int32));
    		table1.Columns.Add(column1);
    		table1.Columns.Add(column2);
    		table1.Columns.Add(column3);
    	
    		// Set the primary key column.
    		table1.PrimaryKey = new DataColumn[] { column1, column2 };
    	
    	
    		// Add some rows.
    		DataRow row;
    		for (int i = 0; i <= 4; i++)
    		{
    			row = table1.NewRow();
    			row["id1"] = i;
    			row["id2"] = i*i;
    			row["item"] = i;
    			table1.Rows.Add(row);
    		}
    	
    		// Accept changes.
    		table1.AcceptChanges();
    		PrintValues(table1, "table1:");
    	
    		// Create a second DataTable identical to the first.
    		DataTable table2 = table1.Clone();
    	
    		// Add a row that exists in table1:
    		row = table2.NewRow();
    		row["id1"] = 0;
    		row["id2"] = 0; 
    		row["item"] = 0;
    		table2.Rows.Add(row);
    	
    		// Modify the values of a row that exists in table1:
    		row = table2.NewRow();
    		row["id1"] = 1;
    		row["id2"] = 1;
    		row["item"] = 455;
    		table2.Rows.Add(row);
    		
    		// Modify the values of a row that exists in table1:
    		row = table2.NewRow();
    		row["id1"] = 2;
    		row["id2"] = 4;
    		row["item"] = 555;
    		table2.Rows.Add(row);
    	
    		// Add a row that does not exist in table1:
    		row = table2.NewRow();
    		row["id1"] = 13;
    		row["id2"] = 169;
    		row["item"] = 655;
    		table2.Rows.Add(row);
    		
    		table2.AcceptChanges();
    		
    		Console.WriteLine();
    		PrintValues(table2, "table2:");
    
    		DataTable delta = GetDelta(table1,table2);
    		
    		Console.WriteLine();
    		PrintValues(delta,"delta:");
    		
    		// Verify that the deltas DataTable contains the adequate Original DataRowVersions:
    		DataTable originals = table1.Clone();
    		foreach (DataRow drow in delta.Rows)
    		{
    			if (drow.RowState != DataRowState.Added)
    			{
    				DataRow originalRow = originals.NewRow();
    				foreach (DataColumn dc in originals.Columns)
    					originalRow[dc.ColumnName] = drow[dc.ColumnName, DataRowVersion.Original];
    				originals.Rows.Add(originalRow);
    			}
    		}
    		originals.AcceptChanges();
    		
    		Console.WriteLine();
    		PrintValues(originals,"delta original values:");
    	}
    	
    	private static void Row_Changed(object sender, 
    		DataRowChangeEventArgs e)
    	{
    		Console.WriteLine("Row changed {0}\t{1}", 
    			e.Action, e.Row.ItemArray[0]);
    	}
    	
    	private static void PrintValues(DataTable table, string label)
    	{
    		// Display the values in the supplied DataTable:
    		Console.WriteLine(label);
    		foreach (DataRow row in table.Rows)
    		{
    			foreach (DataColumn col in table.Columns)
    			{
    				Console.Write("\t " + row[col, row.RowState == DataRowState.Deleted ? DataRowVersion.Original : DataRowVersion.Current].ToString());
    			}
    			Console.Write("\t DataRowState =" + row.RowState);
    			Console.WriteLine();
    		}
    	}
    	
    	public static void Main()
    	{
    		DemonstrateGetDelta();
    	}
    }
