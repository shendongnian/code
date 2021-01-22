    Public Class ProxyCustomer
        Inherits Customer
        Private _name As String
        Public Overrides Property Name() As String
            Get
                Return MyBase.Name ''# Return the original parent property value
            End Get
            Set(ByVal value As String)
                Me._name = value
            End Set
        End Property
    End Class
