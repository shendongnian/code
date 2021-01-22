      <PermissionSet(SecurityAction.Demand, Name:="FullTrust")> _
      Public Class Impersonation
        Implements IDisposable
    
        Public Enum LogonTypes
          ''' <summary>
          ''' This logon type is intended for users who will be interactively using the computer, such as a user being logged on  
          ''' by a terminal server, remote shell, or similar process.
          ''' This logon type has the additional expense of caching logon information for disconnected operations; 
          ''' therefore, it is inappropriate for some client/server applications,
          ''' such as a mail server.
          ''' </summary>
          LOGON32_LOGON_INTERACTIVE = 2
    
          ''' <summary>
          ''' This logon type is intended for high performance servers to authenticate plaintext passwords.
          ''' The LogonUser function does not cache credentials for this logon type.
          ''' </summary>
          LOGON32_LOGON_NETWORK = 3
    
          ''' <summary>
          ''' This logon type is intended for batch servers, where processes may be executing on behalf of a user without 
          ''' their direct intervention. This type is also for higher performance servers that process many plaintext
          ''' authentication attempts at a time, such as mail or Web servers. 
          ''' The LogonUser function does not cache credentials for this logon type.
          ''' </summary>
          LOGON32_LOGON_BATCH = 4
    
          ''' <summary>
          ''' Indicates a service-type logon. The account provided must have the service privilege enabled. 
          ''' </summary>
          LOGON32_LOGON_SERVICE = 5
    
          ''' <summary>
          ''' This logon type is for GINA DLLs that log on users who will be interactively using the computer. 
          ''' This logon type can generate a unique audit record that shows when the workstation was unlocked. 
          ''' </summary>
          LOGON32_LOGON_UNLOCK = 7
    
          ''' <summary>
          ''' This logon type preserves the name and password in the authentication package, which allows the server to make 
          ''' connections to other network servers while impersonating the client. A server can accept plaintext credentials 
          ''' from a client, call LogonUser, verify that the user can access the system across the network, and still 
          ''' communicate with other servers.
          ''' NOTE: Windows NT:  This value is not supported. 
          ''' </summary>
          LOGON32_LOGON_NETWORK_CLEARTEXT = 8
    
          ''' <summary>
          ''' This logon type allows the caller to clone its current token and specify new credentials for outbound connections.
          ''' The new logon session has the same local identifier but uses different credentials for other network connections. 
          ''' NOTE: This logon type is supported only by the LOGON32_PROVIDER_WINNT50 logon provider.
          ''' NOTE: Windows NT:  This value is not supported. 
          ''' </summary>
          LOGON32_LOGON_NEW_CREDENTIALS = 9
        End Enum
    
        <DllImport("advapi32.dll", SetLastError:=True, CharSet:=CharSet.Unicode)> _
        Private Shared Function LogonUser(lpszUsername As [String], lpszDomain As [String], lpszPassword As [String], dwLogonType As Integer, dwLogonProvider As Integer, ByRef phToken As SafeTokenHandle) As Boolean
        End Function
    
        Public Sub New(Domain As String, UserName As String, Password As String, Optional LogonType As LogonTypes = LogonTypes.LOGON32_LOGON_INTERACTIVE)
          Dim ok = LogonUser(UserName, Domain, Password, LogonType, 0, _SafeTokenHandle)
          If Not ok Then
            Dim errorCode = Marshal.GetLastWin32Error()
            Throw New ApplicationException(String.Format("Could not impersonate the elevated user.  LogonUser returned error code {0}.", errorCode))
          End If
    
          WindowsImpersonationContext = WindowsIdentity.Impersonate(_SafeTokenHandle.DangerousGetHandle())
        End Sub
    
        Private ReadOnly _SafeTokenHandle As New SafeTokenHandle
        Private ReadOnly WindowsImpersonationContext As WindowsImpersonationContext
    
        Public Sub Dispose() Implements System.IDisposable.Dispose
          Me.WindowsImpersonationContext.Dispose()
          Me._SafeTokenHandle.Dispose()
        End Sub
    
        Public NotInheritable Class SafeTokenHandle
          Inherits SafeHandleZeroOrMinusOneIsInvalid
    
          <DllImport("kernel32.dll")> _
          <ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)> _
          <SuppressUnmanagedCodeSecurity()> _
          Private Shared Function CloseHandle(handle As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
          End Function
    
          Public Sub New()
            MyBase.New(True)
          End Sub
    
          Protected Overrides Function ReleaseHandle() As Boolean
            Return CloseHandle(handle)
          End Function
        End Class
    
      End Class
