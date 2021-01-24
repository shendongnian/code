	using System;
	using System.Data;
	using System.Linq;
	using System.Linq.Expressions;
	using System.Collections.Generic;
	using Newtonsoft.Json; //just for displaying output
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
				item => item.BranchName, 
				item => new {item.StockId, item.Name},  
				items => items.Any() ? items.Sum(x=>x.Stock) : 0);
			//easy way to view our pivotTable if using linqPad or similar
			//Console.WriteLine(pivotTable);
			//if not using linqPad, convert to JSON for easy display
			Console.WriteLine(JsonConvert.SerializeObject(pivotTable, Formatting.Indented));
		}
	}	
	public static class PivotExtensions
	{
		public static DataTable ToPivotTable<T, TColumn, TRow, TData>(
			this IEnumerable<T> source,
			Func<T, TColumn> columnSelector,
			Expression<Func<T, TRow>> rowSelector,
			Func<IEnumerable<T>, TData> dataSelector)
		{
			DataTable table = new DataTable();
			//foreach (var row in rowSelector()
			var rowNames = GetMemberNames(rowSelector);
			rowNames.ToList().ForEach(x => table.Columns.Add(new DataColumn(x)));
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
		public static IEnumerable<string> GetMemberNames<T1, T2>(Expression<Func<T1, T2>> expression)
		{
			var memberExpression = expression.Body as MemberExpression;
			if (memberExpression != null) 
			{
				return new[]{ memberExpression.Member.Name };
			}
			var memberInitExpression = expression.Body as MemberInitExpression;
			if (memberInitExpression != null)
			{
				return memberInitExpression.Bindings.Select(x => x.Member.Name);
			}
			var newExpression = expression.Body as NewExpression;
			if (newExpression != null)
			{
				return newExpression.Arguments.Select(x => (x as MemberExpression).Member.Name);
			}
			throw new ArgumentException("expression"); //use: `nameof(expression)` if C#6 or above
		}
	}
