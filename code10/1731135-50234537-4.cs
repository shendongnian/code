        Imports Elmah
        Imports System
        Imports System.Web
        Imports System.Runtime.CompilerServices
    Public Module ElmahExtension
        <Extension()>
        Public Sub LogToElmah(ex As Exception)
            
           
            If HttpContext.Current Is Nothing Then
                ErrorLog.GetDefault(Nothing).Log(New [Error](ex))
                Dim req = New HttpRequest(String.Empty, "https://YOURWEBSITE", Nothing)
                Dim res = New HttpResponse(Nothing)
            Else
                ErrorSignal.FromCurrentContext().Raise(ex)
                ErrorLog.GetDefault(HttpContext.Current).Log(New [Error](ex))
            End If
        End Sub
    End Module
