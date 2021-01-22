	Namespace Utils
	''' <summary>
	''' Subclass of WebClient to provide access to the timeout property
	''' </summary>
	Public Class WebClient
		Inherits System.Net.WebClient
	
		Private _TimeoutMS As Integer = 0
	
		Public Sub New()
			MyBase.New()
		End Sub
		Public Sub New(ByVal TimeoutMS As Integer)
			MyBase.New()
			_TimeoutMS = TimeoutMS
		End Sub
		''' <summary>
		''' Set the web call timeout in Milliseconds
		''' </summary>
		''' <value></value>
		Public WriteOnly Property setTimeout() As Integer
			Set(ByVal value As Integer)
				_TimeoutMS = value
			End Set
		End Property
	
	
		Protected Overrides Function GetWebRequest(ByVal address As System.Uri) As System.Net.WebRequest
			Dim w As System.Net.WebRequest = MyBase.GetWebRequest(address)
			If _TimeoutMS <> 0 Then
				w.Timeout = _TimeoutMS
			End If
			Return w
		End Function
	
	End Class
	End Namespace
