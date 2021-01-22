	Imports System.Threading
	Delegate Sub MainDelegate(sender As Anything, original As Boolean)
	Class Main
		Private Const COUNT As Integer = 15
		Private Shared m_list As List(Of Anything)
		Public Shared Sub Main(args As String())
			m_list = New List(Of Anything)(COUNT)
			Dim obj As New AnyTask()
			AddHandler obj.OnUpdate, New MainDelegate(AddressOf ThreadMessages)
			obj.Test_Function(COUNT)
			Console.WriteLine()
			For Each item As Anything In m_list
				Console.WriteLine("[Complete]:" + item.Text)
			Next
			Console.WriteLine("Press any key to exit.")
			Console.ReadKey()
		End Sub
		Private Shared Sub ThreadMessages(item As Anything, original As Boolean)
			If original Then
				Console.WriteLine("[main method]:" + item.Text)
			Else
				m_list.Add(item)
			End If
		End Sub
	End Class
	Class AnyTask
		Private m_lock As Object
		Public Sub New()
			m_lock = New Object()
		End Sub
		' Something to use the delegate
		Public Event OnUpdate As MainDelegate
		Public Sub Test_Function(count As Integer)
			Dim list As New List(Of Thread)(count)
			For i As Int32 = 0 To count - 1
				Dim thread As New Thread(New ParameterizedThreadStart(AddressOf Thread_Task))
				Dim item As New Anything()
				item.Number = i
				item.Text = String.Format("Test_Function #{0}", i)
				thread.Start(item)
				list.Add(thread)
			Next
			For Each thread As Thread In list
				thread.Join()
			Next
		End Sub
		Private Sub MainUpdate(item As Anything, original As Boolean)
			RaiseEvent OnUpdate(item, original)
		End Sub
		Private Sub Thread_Task(parameter As Object)
			SyncLock m_lock
				Dim item As Anything = DirectCast(parameter, Anything)
				MainUpdate(item, True)
				item.Text = [String].Format("{0}; Thread_Task #{1}", item.Text, item.Number)
				item.Number = 0
				MainUpdate(item, False)
			End SyncLock
		End Sub
	End Class
	Class Anything
		' Number and Text are for instructional purposes only
		Public Property Number() As Integer
			Get
				Return m_Number
			End Get
			Set(value As Integer)
				m_Number = value
			End Set
		End Property
		Private m_Number As Integer
		Public Property Text() As String
			Get
				Return m_Text
			End Get
			Set(value As String)
				m_Text = value
			End Set
		End Property
		Private m_Text As String
		' Data can be anything or another class
		Public Property Data() As Object
			Get
				Return m_Data
			End Get
			Set(value As Object)
				m_Data = value
			End Set
		End Property
		Private m_Data As Object
	End Class
