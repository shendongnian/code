    Imports System.Data.Sql
    
    Module Module1
      Sub Main()
        ' Retrieve the enumerator instance and then the data.
        Dim instance As SqlDataSourceEnumerator = SqlDataSourceEnumerator.Instance
        Dim table As System.Data.DataTable = instance.GetDataSources()
    
        ' Display the contents of the table.
        DisplayData(table)
    
        Console.WriteLine("Press any key to continue.")
        Console.ReadKey()
      End Sub
    
      Private Sub DisplayData(ByVal table As DataTable)
        For Each row As DataRow In table.Rows
          For Each col As DataColumn In table.Columns
            Console.WriteLine("{0} = {1}", col.ColumnName, row(col))
          Next
          Console.WriteLine("============================")
        Next
      End Sub
    End Module
