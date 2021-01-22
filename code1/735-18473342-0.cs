    Private Sub ExternalRedirector(ByVal externalUrl As String)
        Dim clientRedirectName As String = "ClientExternalRedirect"
        Dim externalRedirectJS As New StringBuilder()
        If Not String.IsNullOrEmpty(externalUrl) Then
            If Not Page.ClientScript.IsStartupScriptRegistered(clientRedirectName) Then
                externalRedirectJS.Append("function CheckWindow() {")
                externalRedirectJS.Append("   if (window.top != window) {")
                externalRedirectJS.Append("       window.top.location = '")
                externalRedirectJS.Append(externalUrl)
                externalRedirectJS.Append("';")
                externalRedirectJS.Append("       return false;")
                externalRedirectJS.Append("   }")
                externalRedirectJS.Append("   else {")
                externalRedirectJS.Append("   window.location = '")
                externalRedirectJS.Append(externalUrl)
                externalRedirectJS.Append("';")
                externalRedirectJS.Append("   }")
                externalRedirectJS.Append("}")
                externalRedirectJS.Append("CheckWindow();")
                Page.ClientScript.RegisterStartupScript(Page.GetType(), clientRedirectName, externalRedirectJS.ToString(), True)
            End If
        End If
    End Sub
