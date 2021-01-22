    Private Sub FillDatabaseTableWithDataTable(dataTable As DataTable)
    			' inspired by http://stackoverflow.com/a/2671511
    
    			' Query the destination database
    			Dim query As String = $"SELECT * FROM `{dataTable.TableName}`"
    
    			Using adapter As New SQLiteDataAdapter(query, Connection)
    
    				Using commandBuilder = New SQLiteCommandBuilder(adapter)
    
    					Connection.Open()
    
    					commandBuilder.QuotePrefix = "["
    					commandBuilder.QuoteSuffix = "]"
    					commandBuilder.GetInsertCommand()
    
    					'Create an empty "destination" table for synchronization
    					' with SqLite "source" database
    					Dim destinationTable As New DataTable()
    
    					'load data from SqLite "source" database to destination table, e.g.
					    'column headers
					    adapter.Fill(destinationTable)
    
    					'adapt "destination" table: fill data
    					For Each row As DataRow In dataTable.Rows
    						Dim destinationRow As DataRow = destinationTable.NewRow()
    						destinationRow.ItemArray = row.ItemArray
    						destinationTable.Rows.Add(destinationRow)
    					Next
    
    					'Update SqLite source table
    					'the Update has To be wrapped In a transaction
    					'Otherwise, SQLite would implicitly create a transaction
    					'for each line. That would slow down the writing process.
    					Using transaction = Connection.BeginTransaction()
    						adapter.Update(destinationTable)
    						transaction.Commit()
    					End Using
    
    					Connection.Close()
    				End Using
    			End Using
    		End Sub
