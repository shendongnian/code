    Namespace DataSet1TableAdapters
        Partial Public Class Table1TableAdapter
            Public Overrides ReadOnly Property MyCommandCollection As System.Data.SqlClient.SqlCommand()
                Get
                    Return Me.CommandCollection
                End Get
            End Property
        End Class
        
        Partial Public Class Table2TableAdapter
            Public Overrides ReadOnly Property MyCommandCollection As System.Data.SqlClient.SqlCommand()
                Get
                    Return Me.CommandCollection
                End Get
            End Property
        End Class
    End Namespace
