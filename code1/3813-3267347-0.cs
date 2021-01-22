	Imports Domino
	Imports System.Threading
	Public Class AffinitedSession
		Implements IDisposable
		Private _session As NotesSession
		Public Sub New(ByVal pass As String)
			Thread.BeginThreadAffinity()
			_session = New NotesSession()
			_session.Initialize(pass)
		End Sub
		Public ReadOnly Property NotesSession() As NotesSession
			Get
				Return _session
			End Get
		End Property
		Private disposedValue As Boolean = False        ' To detect redundant calls
		' IDisposable
		Protected Overridable Sub Dispose(ByVal disposing As Boolean)
			If Not Me.disposedValue Then
				If disposing Then
					' TODO: free other state (managed objects).
				End If
				' TODO: free your own state (unmanaged objects).
				' TODO: set large fields to null.
				_session = Nothing
				Thread.EndThreadAffinity()
			End If
			Me.disposedValue = True
		End Sub
	#Region " IDisposable Support "
		' This code added by Visual Basic to correctly implement the disposable pattern.
		Public Sub Dispose() Implements IDisposable.Dispose
			' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
			Dispose(True)
			GC.SuppressFinalize(Me)
		End Sub
	#End Region
	End Class
