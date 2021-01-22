    Imports Microsoft.Office.Interop
    Public Class OutlookClientHandler
    Private _application As Outlook.Application
    Private _namespace As Outlook.NameSpace
    Public Sub New()
        If Process.GetProcessesByName("outlook".ToLower).Length > 0 Then
            _application = New Outlook.Application
        Else
            Dim startInfo As ProcessStartInfo = New ProcessStartInfo("outlook.exe")
            startInfo.WindowStyle = ProcessWindowStyle.Minimized
            Process.Start(startInfo)
            _application = New Outlook.Application
        End If
    End Sub
    ' Retrieves the specified e-mail from Outlook/Exchange via the MAPI
    Public Function GetMailItem(ByVal entryID as String, ByVal storeID as String) As Outlook.MailItem
        _namespace = _application.GetNamespace("MAPI")
        Dim item As Outlook.MailItem
        Try
            item = _namespace.GetItemFromID(entryID, storeID)
        Catch comex As COMException
            item = Nothing ' Fugly, e-mail wasn't found!
        End Try
        Return item
    End Function
    End Class
