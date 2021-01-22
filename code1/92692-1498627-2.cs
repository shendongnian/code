    Public Class ProxyCustomer
        Inherits Customer
 
        Public Overrides Property Name() As String
            Get
                Return MyBase.Name ''# Return the original parent property value
            End Get
            Set(ByVal value As String)
                MyBase.Name = value
            End Set
        End Property
    End Class
