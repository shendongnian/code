    Imports System
    Imports System.Net
    Imports System.Runtime.InteropServices
    Imports System.ComponentModel
    
    Public Class NetworkConnection
        Implements IDisposable
    
        Private _networkName As String
    
        Public Sub New(networkName As String, credentials As NetworkCredential)
            _networkName = networkName
    
            Dim netResource = New NetResource() With {
                 .Scope = ResourceScope.GlobalNetwork,
                 .ResourceType = ResourceType.Disk,
                 .DisplayType = ResourceDisplaytype.Share,
                 .RemoteName = networkName
            }
    
            Dim userName = If(String.IsNullOrEmpty(credentials.Domain), credentials.UserName, String.Format("{0}\{1}", credentials.Domain, credentials.UserName))
    
            Dim result = WNetAddConnection2(NetResource, credentials.Password, userName, 0)
    
            If result <> 0 Then
                Throw New Win32Exception(result, "Error connecting to remote share")
            End If
        End Sub
    
        Protected Overrides Sub Finalize()
            Try
                Dispose (False)
            Finally
                MyBase.Finalize()
            End Try
        End Sub
    
        Public Sub Dispose() Implements IDisposable.Dispose
            Dispose (True)
            GC.SuppressFinalize (Me)
        End Sub
    
        Protected Overridable Sub Dispose(disposing As Boolean)
            WNetCancelConnection2(_networkName, 0, True)
        End Sub
    
        <DllImport("mpr.dll")> _
        Private Shared Function WNetAddConnection2(netResource As NetResource, password As String, username As String, flags As Integer) As Integer
        End Function
    
        <DllImport("mpr.dll")> _
        Private Shared Function WNetCancelConnection2(name As String, flags As Integer, force As Boolean) As Integer
        End Function
    
    End Class
    
    <StructLayout(LayoutKind.Sequential)> _
    Public Class NetResource
        Public Scope As ResourceScope
        Public ResourceType As ResourceType
        Public DisplayType As ResourceDisplaytype
        Public Usage As Integer
        Public LocalName As String
        Public RemoteName As String
        Public Comment As String
        Public Provider As String
    End Class
    
    Public Enum ResourceScope As Integer
        Connected = 1
        GlobalNetwork
        Remembered
        Recent
        Context
    End Enum
    
    Public Enum ResourceType As Integer
        Any = 0
        Disk = 1
        Print = 2
        Reserved = 8
    End Enum
    
    Public Enum ResourceDisplaytype As Integer
        Generic = &H0
        Domain = &H1
        Server = &H2
        Share = &H3
        File = &H4
        Group = &H5
        Network = &H6
        Root = &H7
        Shareadmin = &H8
        Directory = &H9
        Tree = &HA
        Ndscontainer = &HB
    End Enum
    
    
