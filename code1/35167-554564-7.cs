    Public MustInherit Class Parent
      Public MustOverride Property Foo() As String
    End Class
    Public Class ReadOnlyChild
      Inherits Parent
      Public Overrides Property Foo() As String
        Get
            '
        End Get
        Private Set(ByVal value As String)
            '
        End Set
      End Property
    End Class
