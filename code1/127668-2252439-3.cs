    <ComClass(Calculator.ClassId, Calculator.InterfaceId, Calculator.EventsId)> _
    Public Class Calculator
        Implements IDisposable
    #Region "COM GUIDs"
        ' These  GUIDs provide the COM identity for this class 
        ' and its COM interfaces. If you change them, existing 
        ' clients will no longer be able to access the class.
        Public Const ClassId As String = "68b420b3-3aa2-404a-a2d5-fa7497ad0ebc"
        Public Const InterfaceId As String = "0da9ab1a-176f-49c4-9334-286a3ad54353"
        Public Const EventsId As String = "ce93112f-d45e-41ba-86a0-c7d5a915a2c9"
    #End Region
        ' A creatable COM class must have a Public Sub New() 
        ' with no parameters, otherwise, the class will not be 
        ' registered in the COM registry and cannot be created 
        ' via CreateObject.
        Public Sub New()
            MyBase.New()
        End Sub
        Public Function Add(ByVal x As Double, ByVal y As Double) As Double
            Return x + y
        End Function
        Private disposedValue As Boolean = False        ' To detect redundant calls
        ' IDisposable
        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    MsgBox("Disposed called on .NET COM Calculator.")
                End If
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
