	using System;
	using System.Data;
	using System.Linq;
	using System.Linq.Expressions;
	using System.Collections.Generic;
	public class Program
	{
		public static void Main()
		{
			var data = new[] { 
				new { StockId = 65, Name = "Milk", Branch = 23, BranchName = "Branch 1", Stock = 3 },
				new { StockId = 65, Name = "Milk", Branch = 24, BranchName = "Branch 2", Stock = 1 },
				new { StockId = 67, Name = "Coffee", Branch = 22, BranchName = "Central Branch", Stock = 22 }
			};
			var pivotTable = data.ToPivotTable(
				  item => new {item.Branch,item.BranchName}, 
				  item => item.Name,  
				  items => items.Any() ? items.Sum(x=>x.Stock) : 0);
			//this is just here for displaying the result		
			foreach(DataRow row in pivotTable.Rows)
			{
				var stockId = ""; //row["StockId"].ToString();
				var name = row[0].ToString();
				var b1 = Int32.Parse(row[1].ToString());
				var b2 = Int32.Parse(row[2].ToString());
				var cb = Int32.Parse(row[3].ToString()); //we use ints to index, since the column name is actually an object: `{ Branch = 22, BranchName = Central Branch }`
				var total = b1 + b2 + cb;
				Console.WriteLine(string.Format("{0}\t|\t{1}\t|\t{2}\t|\t{3}\t|\t{4}\t|\t{5}", stockId, name, b1, b2, cb, total));
			}
		}
	}
	public static class PivotThing
	{
		public static DataTable ToPivotTable<T, TColumn, TRow, TData>(
			this IEnumerable<T> source,
			Func<T, TColumn> columnSelector,
			Expression<Func<T, TRow>> rowSelector,
			Func<IEnumerable<T>, TData> dataSelector)
		{
			DataTable table = new DataTable();
			var rowName = ((MemberExpression)rowSelector.Body).Member.Name;
			table.Columns.Add(new DataColumn(rowName));
			var columns = source.Select(columnSelector).Distinct();
			foreach (var column in columns)
				table.Columns.Add(new DataColumn(column.ToString()));
			var rows = source.GroupBy(rowSelector.Compile())
				.Select(rowGroup => new
						{
							Key = rowGroup.Key,
							Values = columns.GroupJoin(
								rowGroup,
								c => c,
								r => columnSelector(r),
								(c, columnGroup) => dataSelector(columnGroup))
						});
			foreach (var row in rows)
			{
				var dataRow = table.NewRow();
				var items = row.Values.Cast<object>().ToList();
				items.Insert(0, row.Key);
				dataRow.ItemArray = items.ToArray();
				table.Rows.Add(dataRow);
			}
			return table;
		}
	}
