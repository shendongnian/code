	Public Class DropDownList
		Inherits System.Web.UI.WebControls.DropDownList
		Private _SelectedIndex As Integer? = -1
		Private _SelectedValue As String = Nothing
		Private _StateFromClient As Boolean = False
		Private _StateFromLocal As Boolean = False
		Protected Overrides Sub OnInit(ByVal e As EventArgs)
			MyBase.OnInit(e)
			Page.RegisterRequiresControlState(Me)
		End Sub
		Public Overrides Property SelectedIndex() As Integer
			Get
				If Not _StateFromLocal Then
					Me.LoadStateFromClient()
					If _StateFromClient Then
						Return _SelectedIndex
					End If
				End If
				Return MyBase.SelectedIndex
			End Get
			Set(ByVal value As Integer)
				_StateFromLocal = True
				MyBase.SelectedIndex = value
			End Set
		End Property
		Public Overrides Property SelectedValue() As String
			Get
				If Not _StateFromLocal Then
					LoadStateFromClient()
					If _StateFromClient Then
						Return _SelectedValue
					End If
				End If
				Return MyBase.SelectedValue
			End Get
			Set(ByVal value As String)
				_StateFromLocal = True
				MyBase.SelectedValue = value
			End Set
		End Property
		Private Sub LoadStateFromClient()
			If _StateFromClient Then Return
			If _StateFromLocal Then Return
			If Me.IsViewStateEnabled Then Return
			If Not Me.Page.IsPostBack Then Return
			If Not _SelectedIndex.HasValue Then
				Throw New Exception("ControlState has not yet been loaded and so state does not exist.")
			End If
			_SelectedValue = Me.Page.Request.Form(Me.UniqueID)
			_StateFromClient = True
		End Sub
		Protected Overrides Sub PerformSelect()
			' Called when DataBound() is called, which can affect the Selected* property values
			_StateFromLocal = True
			MyBase.PerformSelect()
		End Sub
		Protected Overrides Function SaveControlState() As Object
			Dim state As Object = MyBase.SaveControlState()
			If Me.SelectedIndex >= 0 Then
				If state IsNot Nothing Then
					Return New Pair(state, Me.SelectedIndex)
				Else
					Return Me.SelectedIndex
				End If
			Else
				Return state
			End If
		End Function
		Protected Overrides Sub LoadControlState(ByVal state As Object)
			If state IsNot Nothing Then
				Dim p As Pair = TryCast(state, Pair)
				If p IsNot Nothing Then
					MyBase.LoadControlState(p.First)
					_SelectedIndex = CInt(p.Second)
				Else
					If (TypeOf (state) Is Integer) Then
						_SelectedIndex = CInt(state)
					Else
						MyBase.LoadControlState(state)
					End If
				End If
			End If
			MyBase.SelectedIndex = _SelectedIndex
		End Sub
	End Class
	
