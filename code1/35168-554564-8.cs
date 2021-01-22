    Public MustInherit Class Parent
      Protected MustOverride Property Foo() As String       
    End Class
    Public Class ReadOnlyChild
      Inherits Parent
      Protected Overrides Property Foo() As String
          Public Get
              '
          End Get
          Set(ByVal value As String)
              '
          End Set
      End Property
    End Class
