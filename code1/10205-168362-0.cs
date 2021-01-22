    Private Sub assignApplicationPool(ByVal WebSite As String, ByVal Vdir As String, ByVal appPool As String)
       Try
         Dim IISVdir As New DirectoryEntry(String.Format("IIS://{0}/W3SVC/1/Root/{1}", WebSite, Vdir))
         IISVdir.Properties.Item("AppPoolId").Item(0) = appPool
         IISVdir.CommitChanges()
       Catch ex As Exception
         Throw ex
       End Try
     End Sub
    
     Private strServer As String = "localhost"
     Private strRootSubPath As String = "/W3SVC/1/Root"
     Private strSchema As String = "IIsWebVirtualDir"
     Public Overrides Sub Install(ByVal stateSaver As IDictionary)
       MyBase.Install(stateSaver)
       Try
         Dim webAppName As String = MyBase.Context.Parameters.Item("TARGETVDIR").ToString
         Dim vdirName As String = MyBase.Context.Parameters.Item("COMMONVDIR").ToString
         Me.assignApplicationPool(Me.strServer, MyBase.Context.Parameters.Item("TARGETVDIR").ToString, MyBase.Context.Parameters.Item("APPPOOL").ToString)
       Catch ex As Exception
         Throw ex
       End Try
     End Sub
