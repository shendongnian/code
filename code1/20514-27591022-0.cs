    Imports System.Net
    Public Module Network_Monitor
    Private InsideWorkNet As Boolean = vbFalse
    Private Online_Status As Boolean = vbFalse
    Private CurrentWorkIPAddress As New IPHostEntry
    Private WithEvents Timer_Online_Check As New Timers.Timer With {.Interval = 5000, .Enabled = True, .AutoReset = True}
    Public ReadOnly Property GetOnlineStatus() As String
        Get
            Return Online_Status
        End Get
    End Property
    Public Sub Initialize()
        Set_Online_Status()
        Timer_Online_Check.Start()
    End Sub
    Public Sub Set_Online_Status()
        If My.Computer.Network.IsAvailable Then
            Try
                Dim DNSTest As IPHostEntry = Dns.GetHostEntry("google.com")
                If DNSTest.AddressList.Length > 0 Then
                    Online_Status = True
                Else : Online_Status = False
                End If
            Catch ex As System.Net.Sockets.SocketException
                Online_Status = False
            End Try
        End If
    End Sub
    Private Sub Timer_Online_Check_Elaspsed(ByVal sender As Object, ByVal e As Timers.ElapsedEventArgs) Handles Timer_Online_Check.Elapsed
        Set_Online_Status()
    End Sub
    Public Sub Detect_Work_Network()
        If Online_Status = True Then
            Dim WorkIP As IPHostEntry = New IPHostEntry()
            Try
                WorkIP = Dns.GetHostEntry("serverA.myworkdomain.local")
                If WorkIP.AddressList.Length > 0 Then
                    InsideWorkNet = True
                    CurrentWorkIPAddress = WorkIP
                    'MessageBox.Show(WorkIP.HostName.ToString(), "WorkIP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Catch ex As Sockets.SocketException
                Try
                    WorkIP = Dns.GetHostEntry("serverA.myworkdomain.com")
                    If WorkIP.AddressList.Length > 0 Then
                        InsideWorkNet = False
                        CurrentWorkIPAddress = WorkIP
                        ' MessageBox.Show(WorkIP.HostName.ToString(), "WorkIP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Catch ey As Sockets.SocketException
                End Try
            End Try
        End If
    End Sub
    Public Function GetWorkServerName() As String
        If InsideWorkNet = True Then
            Return "serverA.myworkdomain.local"
        Else : Return "serverA.myworkdomain.com"
        End If
    End Function
    End Module
