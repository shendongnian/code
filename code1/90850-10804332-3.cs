    Imports System.Data.SqlClient
    Imports System.Data
    Imports System.Threading.Tasks
    Public Class DataAccess
    Implements IDisposable
    #Region "   Properties  "
    ''' <summary>
    ''' Set the Query Type
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Public WriteOnly Property QueryType() As CmdType
        Set(ByVal value As CmdType)
            _QT = value
        End Set
    End Property
    Private _QT As CmdType
    ''' <summary>
    ''' Set the query to run
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Public WriteOnly Property Query() As String
        Set(ByVal value As String)
            _Qry = value
        End Set
    End Property
    Private _Qry As String
    ''' <summary>
    ''' Set the parameter names
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Public WriteOnly Property ParameterNames() As Object
        Set(ByVal value As Object)
            _PNs = value
        End Set
    End Property
    Private _PNs As Object
    ''' <summary>
    ''' Set the parameter values
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Public WriteOnly Property ParameterValues() As Object
        Set(ByVal value As Object)
            _PVs = value
        End Set
    End Property
    Private _PVs As Object
    ''' <summary>
    ''' Set the parameter data type
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Public WriteOnly Property ParameterDataTypes() As DataType()
        Set(ByVal value As DataType())
            _DTs = value
        End Set
    End Property
    Private _DTs As DataType()
    ''' <summary>
    ''' Check if there are parameters, before setting them
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private ReadOnly Property AreParams() As Boolean
        Get
            If (IsArray(_PVs) And IsArray(_PNs)) Then
                If (_PVs.GetUpperBound(0) = _PNs.GetUpperBound(0)) Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        End Get
    End Property
    ''' <summary>
    ''' Set our dynamic connection string
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private ReadOnly Property _ConnString() As String
        Get
            If System.Diagnostics.Debugger.IsAttached OrElse My.Settings.AttachToBeta OrElse Not (Common.CheckPaid) Then
                Return My.Settings.DevConnString
            Else
                Return My.Settings.TurboKitsv2ConnectionString
            End If
        End Get
    End Property
    Private _Rdr As SqlDataReader
    Private _Conn As SqlConnection
    Private _Cmd As SqlCommand
    #End Region
    #Region "   Methods "
    ''' <summary>
    ''' Fire us up!
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        Parallel.Invoke(Sub()
                            _Conn = New SqlConnection(_ConnString)
                        End Sub,
                        Sub()
                            _Cmd = New SqlCommand
                        End Sub)
    End Sub
    ''' <summary>
    ''' Get our results
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetResults() As SqlDataReader
        Try
            Parallel.Invoke(Sub()
                                If AreParams Then
                                    PrepareParams(_Cmd)
                                End If
                                _Cmd.Connection = _Conn
                                _Cmd.CommandType = _QT
                                _Cmd.CommandText = _Qry
                                _Cmd.Connection.Open()
                                _Rdr = _Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                            End Sub)
            If _Rdr.HasRows Then
                Return _Rdr
            Else
                Return Nothing
            End If
        Catch sEx As SqlException
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    ''' <summary>
    ''' Prepare our parameters
    ''' </summary>
    ''' <param name="objCmd"></param>
    ''' <remarks></remarks>
    Private Sub PrepareParams(ByVal objCmd As Object)
        Try
            Dim _DataSize As Long
            Dim _PCt As Integer = _PVs.GetUpperBound(0)
            For i As Long = 0 To _PCt
                If IsArray(_DTs) Then
                    Select Case _DTs(i)
                        Case 0, 33, 6, 9, 13, 19
                            _DataSize = 8
                        Case 1, 3, 7, 10, 12, 21, 22, 23, 25
                            _DataSize = Len(_PVs(i))
                        Case 2, 20
                            _DataSize = 1
                        Case 5
                            _DataSize = 17
                        Case 8, 17, 15
                            _DataSize = 4
                        Case 14
                            _DataSize = 16
                        Case 31
                            _DataSize = 3
                        Case 32
                            _DataSize = 5
                        Case 16
                            _DataSize = 2
                        Case 15
                    End Select
                    objCmd.Parameters.Add(_PNs(i), _DTs(i), _DataSize).Value = _PVs(i)
                Else
                    objCmd.Parameters.AddWithValue(_PNs(i), _PVs(i))
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub
    #End Region
    #Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls
    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
            End If
            Try
                Erase _PNs : Erase _PVs : Erase _DTs
                _Qry = String.Empty
                _Rdr.Close()
                _Rdr.Dispose()
                _Cmd.Parameters.Clear()
                _Cmd.Connection.Close()
                _Conn.Close()
                _Cmd.Dispose()
                _Conn.Dispose()
            Catch ex As Exception
            End Try
        End If
        Me.disposedValue = True
    End Sub
    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    Protected Overrides Sub Finalize()
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(False)
        MyBase.Finalize()
    End Sub
    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
    #End Region
    End Class
