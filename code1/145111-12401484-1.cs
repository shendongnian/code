	Public Interface IFoo
		Property Description() As String
	End Interface
	Public MustInherit Class FooBase
		Implements IFoo
		Public MustOverride Property Description As String Implements IFoo.Description
	End Class
	Public Class MyFoo
		Inherits FooBase
		Private _description As String
		Public Overrides Property Description As String
			Get
				Return _description
			End Get
			Set(value As String)
				_description = value
			End Set
		End Property
	End Class
