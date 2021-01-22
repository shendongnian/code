	Option Strict On
	Option Explicit On
	Imports System
	Imports System.Windows.Forms
	Public Class ExtendedTabControl
		Inherits TabControl
		Public Shadows Event Selecting As EventHandler(Of SelectedTabChangingEventArgs)
		Public Shadows Event Selected As EventHandler(Of SelectedTabChangedEventArgs)
		Private _PreviousTab As TabPage
		Public Property PreviousTab() As TabPage
			Get
				Return _PreviousTab
			End Get
			Private Set(ByVal value As TabPage)
				_PreviousTab = value
			End Set
		End Property
		Private _CurrentTab As TabPage
		Public Property CurrentTab() As TabPage
			Get
				Return _CurrentTab
			End Get
			Private Set(ByVal value As TabPage)
				_CurrentTab = value
			End Set
		End Property
		Protected Overrides Sub OnDeselected(ByVal e As System.Windows.Forms.TabControlEventArgs)
			PreviousTab = e.TabPage
			MyBase.OnDeselected(e)
		End Sub
		Protected Overrides Sub OnSelected(ByVal e As System.Windows.Forms.TabControlEventArgs)
			CurrentTab = e.TabPage
			Dim selectedArgs As New SelectedTabChangedEventArgs(e, PreviousTab)
			RaiseEvent Selected(Me, selectedArgs)
		End Sub
		Protected Overrides Sub OnSelecting(ByVal e As System.Windows.Forms.TabControlCancelEventArgs)
			Dim selectedArgs As New SelectedTabChangingEventArgs(e, CurrentTab)
			RaiseEvent Selecting(Me, selectedArgs)
		End Sub
	End Class
	Public Class SelectedTabChangingEventArgs
		Inherits TabControlCancelEventArgs
		Public Sub New(ByVal selectingEventArgs As TabControlCancelEventArgs, ByVal previousTabPage As TabPage)
			MyBase.New(selectingEventArgs.TabPage, selectingEventArgs.TabPageIndex, selectingEventArgs.Cancel, selectingEventArgs.Action)
			Me.CurrentTab = previousTabPage
		End Sub
		Private _CurrentTab As TabPage
		Public Property CurrentTab() As TabPage
			Get
				Return _CurrentTab
			End Get
			Set(ByVal value As TabPage)
				_CurrentTab = value
			End Set
		End Property
	End Class
	Public Class SelectedTabChangedEventArgs
		Inherits TabControlEventArgs
		Public Sub New(ByVal selectedEventArgs As TabControlEventArgs, ByVal previousTabPage As TabPage)
			MyBase.New(selectedEventArgs.TabPage, selectedEventArgs.TabPageIndex, selectedEventArgs.Action)
			Me.PreviousTab = previousTabPage
		End Sub
		Private _PreviousTab As TabPage
		Public Property PreviousTab() As TabPage
			Get
				Return _PreviousTab
			End Get
			Set(ByVal value As TabPage)
				_PreviousTab = value
			End Set
		End Property
	End Class
