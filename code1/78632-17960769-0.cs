    Imports System.Configuration
    Public Function GetAppVersion() As String
        Dim ass As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
        Dim ver As System.Version = ass.GetName().Version
        Return ver.Major & "." & ver.Minor & "." & ver.Revision
    End Function
