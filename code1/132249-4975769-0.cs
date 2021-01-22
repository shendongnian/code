    Class BlankTableWithSourceTableSchema
        Inherits DataTable
        Public Sub New(ByVal connstr As String, ByVal sourcetable As String)
            Try
                Using connection As SqlServerCe.SqlCeConnection = New SqlServerCe.SqlCeConnection(connstr)
                    Dim adapter As SqlServerCe.SqlCeDataAdapter = New SqlServerCe.SqlCeDataAdapter("SELECT * FROM " & sourcetable, connection)
                    adapter.TableMappings.Add("Table", "ABlankTable")
                    adapter.FillSchema(Me, SchemaType.Mapped)
                End Using
            Catch ex As Exception
            End Try
        End Sub
    End Class
