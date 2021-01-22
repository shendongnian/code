	Option Strict On
	Option Explicit On
	
	Interface INamedObject
		Property Name() As String
	End Interface
	MustInherit Class MyBaseClass
		Sub PrintType()
			Console.WriteLine(Me.GetType.Name)
		End Sub
	End Class
	Class MyConcreteClass
		Inherits MyBaseClass
		Implements INamedObject
		Public Sub New()
			MyBase.New()
		End Sub
		Private _Name As String
		Public Property Name() As String Implements INamedObject.Name
			Get
				Return _Name
			End Get
			Set(ByVal value As String)
				_Name = value
			End Set
		End Property
	End Class
