    ' following methods will be defined in a module, which is why they aren't Shared
	' based on https://codecorner.galanter.net/2013/08/02/ado-net-datatable-change-column-datatype-after-table-is-populated-with-data/ 
	' and https://stackoverflow.com/a/15692087/1200847 
	''' <summary> 
	''' Converts DataType of a DataTable's column to a new type by creating a copy of the column with the new type and removing the old one. 
	''' </summary> 
	''' <param name="table">DataTable containing the column</param> 
	''' <param name="columnName">Name of the column</param> 
	''' <param name="newType">New type of the column</param> 
	<Extension()> 
	Public Sub ChangeColumnDataType(table As DataTable, columnName As String, newType As Type) 
		If Not table.Columns.Contains(columnName) Then Throw New ArgumentException($"No column of the given table is named ""{columnName}"".") 
		Dim oldCol As DataColumn = table.Columns(columnName) 
		oldCol.ChangeDataType(newType) 
	End Sub 
 
	''' <summary> 
	''' Converts DataType of a DataTable's column to a new type by creating a copy of the column with the new type and removing the old one. 
	''' </summary> 
	''' <param name="column">The column whichs type should be changed</param> 
	''' <param name="newType">New type of the column</param> 
	<Extension()> 
	Public Sub ChangeDataType(column As DataColumn, newType As Type) 
		Dim table = column.Table 
		If column.DataType Is newType Then Return 
 
		Dim tempColName = "temporary-327b8efdb7984e4d82d514230b92a137" 
		Dim newCol As New DataColumn(tempColName, newType) 
		newCol.AllowDBNull = column.AllowDBNull 
 
		table.Columns.Add(newCol) 
		newCol.SetOrdinal(table.Columns.IndexOf(column)) 
 
		For Each row As DataRow In table.Rows 
			row(tempColName) = Convert.ChangeType(row(column), newType) 
		Next 
		table.Columns.Remove(column) 
		newCol.ColumnName = column.ColumnName 
	End Sub
