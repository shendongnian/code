    Imports Microsoft.Win32
    Imports System
    Imports System.Collections.Generic
    Imports System.IO
    Imports System.Linq
    Imports System.Security
    Imports System.Text
    Imports System.Threading.Tasks
    
    Public Enum BrowserEmulationVersion
        [Default] = 0
        Version7 = 7000
        Version8 = 8000
        Version8Standards = 8888
        Version9 = 9000
        Version9Standards = 9999
        Version10 = 10000
        Version10Standards = 10001
        Version11 = 11000
        Version11Edge = 11001
    End Enum
    
    
    Public Class WBEmulator
        Private Const InternetExplorerRootKey As String = "Software\Microsoft\Internet Explorer"
        Public Shared Function GetInternetExplorerMajorVersion() As Integer
    
            Dim result As Integer
    
            result = 0
    
            Try
                Dim key As RegistryKey
                key = Registry.LocalMachine.OpenSubKey(InternetExplorerRootKey)
                If key IsNot Nothing Then
                    Dim value As Object = If(key.GetValue("svcVersion", Nothing), key.GetValue("Version", Nothing))
    
                    Dim Version As String
                    Dim separator As Integer
                    Version = value.ToString()
                    separator = Version.IndexOf(".")
                    If separator <> -1 Then
                        Integer.TryParse(Version.Substring(0, separator), result)
                    End If
                End If
    
            Catch ex As SecurityException
                'The user does Not have the permissions required to read from the registry key.
            Catch ex As UnauthorizedAccessException
                'The user does Not have the necessary registry rights.
            Catch
    
            End Try
            GetInternetExplorerMajorVersion = result
        End Function
        Private Const BrowserEmulationKey = InternetExplorerRootKey + "\Main\FeatureControl\FEATURE_BROWSER_EMULATION"
    
        Public Shared Function GetBrowserEmulationVersion() As BrowserEmulationVersion
    
            Dim result As BrowserEmulationVersion
            result = BrowserEmulationVersion.Default
    
            Try
                Dim key As RegistryKey = Registry.CurrentUser.OpenSubKey(BrowserEmulationKey, True)
                If key IsNot Nothing Then
                    Dim programName As String
                    Dim value As Object
                    programName = Path.GetFileName(Environment.GetCommandLineArgs()(0))
                    value = key.GetValue(programName, Nothing)
                    If value IsNot Nothing Then
                        result = CType(Convert.ToInt32(value), BrowserEmulationVersion)
                    End If
                End If
            Catch ex As SecurityException
                'The user does Not have the permissions required to read from the registry key.
            Catch ex As UnauthorizedAccessException
                'The user does Not have the necessary registry rights.
            Catch
    
            End Try
    
            GetBrowserEmulationVersion = result
        End Function
        Public Shared Function SetBrowserEmulationVersion(BEVersion As BrowserEmulationVersion) As Boolean
    
            Dim result As Boolean = False
    
            Try
                Dim key As RegistryKey = Registry.CurrentUser.OpenSubKey(BrowserEmulationKey, True)
                If key IsNot Nothing Then
                    Dim programName As String = Path.GetFileName(Environment.GetCommandLineArgs()(0))
                    If BEVersion <> BrowserEmulationVersion.Default Then
                        'if it's a valid value, update or create the value
                        key.SetValue(programName, CType(BEVersion, Integer), RegistryValueKind.DWord)
                    Else
                        'otherwise, remove the existing value
                        key.DeleteValue(programName, False)
                    End If
                    result = True
                End If
            Catch ex As SecurityException
    
                ' The user does Not have the permissions required to read from the registry key.
    
            Catch ex As UnauthorizedAccessException
    
                ' The user does Not have the necessary registry rights.
    
            End Try
    
            SetBrowserEmulationVersion = result
        End Function
    
    
        Public Shared Function SetBrowserEmulationVersion() As Boolean
            Dim ieVersion As Integer
            Dim emulationCode As BrowserEmulationVersion
            ieVersion = GetInternetExplorerMajorVersion()
    
            If ieVersion >= 11 Then
    
                emulationCode = BrowserEmulationVersion.Version11
            Else
    
                Select Case ieVersion
                    Case 10
                        emulationCode = BrowserEmulationVersion.Version10
                    Case 9
                        emulationCode = BrowserEmulationVersion.Version9
                    Case 8
                        emulationCode = BrowserEmulationVersion.Version8
                    Case Else
                        emulationCode = BrowserEmulationVersion.Version7
                End Select
            End If
    
            SetBrowserEmulationVersion = SetBrowserEmulationVersion(emulationCode)
        End Function
    
        Public Shared Function IsBrowserEmulationSet() As Boolean
            IsBrowserEmulationSet = GetBrowserEmulationVersion() <> BrowserEmulationVersion.Default
        End Function
    End Class
