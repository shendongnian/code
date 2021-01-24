        Usage example:
        var command = "SELECT 'just a string' as Type, NAME  FROM SCHEMA.PERSON where NAME like ('%A%')";
        var query = _Session.CreateSQLQuery(command)
                    .SetResultTransformer(new DataTableTransformer());
        var dataTable = (DataTable)query.List()[0];
        
        Implementation:
        public class DataTableTransformer : IResultTransformer
		{
			bool _isHeaderRowAdded;
			public object TransformTuple(object[] tuple, string[] aliases)
			{
				if (false == _isHeaderRowAdded)
				{
					_isHeaderRowAdded = true;
					return new Tuple<string[], object[]>(aliases, tuple);
				}
				return tuple;
			}
			public IList TransformList(IList collection)
			{
				if (collection.Count == 0)
				{
					return new []{new DataTable()};
				}
				var dataTable = new DataTable();
				var headerAndFirstRow = (Tuple<string[], object[]>)collection[0];
				foreach (var columnName in headerAndFirstRow.Item1)
				{
					dataTable.Columns.Add(columnName);
				}
				var newRow = dataTable.NewRow();
				newRow.ItemArray = headerAndFirstRow.Item2;
				dataTable.Rows.Add(newRow);
				int index = 0;
				foreach (var item in collection)
				{
					if (index++ == 0) continue;
					var dataRow = dataTable.NewRow();
					dataRow.ItemArray = (object[])item;
					dataTable.Rows.Add(dataRow);
				}
				return new []{dataTable};
			}
		}
