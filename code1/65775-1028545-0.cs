	Namespace AdventureWorksPurchasingDSTableAdapters
	    Partial Public Class SalesOrderHeaderTableAdapter
		Public Property SelectCommandTimeout() As Integer
		    Get
			Return Adapter.SelectCommand.CommandTimeout
		    End Get
		    Set(ByVal value As Integer)
			Adapter.SelectCommand.CommandTimeout = value
		    End Set
		End Property
	    End Class
	End Namespace
