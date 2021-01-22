    Public Function WSSUpdateFile(ByVal sFileName As String, ByVal sSiteDoc As String, ByVal sTestCol As String) As String
    
            Dim sUser As String = ConfigurationManager.AppSettings("User")
            Dim sPwd As String = ConfigurationManager.AppSettings("Pwd")
            Dim sDomain As String = ConfigurationManager.AppSettings("Domain")
            Dim sFileIDinList As String
            Dim strBatch As String = ""
            sSiteDoc = Replace(sSiteDoc, "%20", " ")
            sSiteDoc = Replace(sSiteDoc, "\", "/")
            Dim sFinalFilePath As String
            Dim sSPURL As String = ConfigurationManager.AppSettings("SharePointServer")
            Dim sDocLib As String = ConfigurationManager.AppSettings("DocLibrary")
            Try
                Dim netAccess As System.Net.NetworkCredential = New System.Net.NetworkCredential(sUser, sPwd, sDomain)
                Dim listService As New SPLists.Lists
                listService.Url = sSPURL & "/_vti_bin/lists.asmx"
                listService.Credentials = netAccess
                sFileIDinList = sGetID(listService.Url, sDocLib, sFileName)
                If sFileIDinList <> "" Then
                    sFinalFilePath = sSPURL & "/" & sDocLib & "/" & sFileName
                    'Now we have FileID so update the list
                    strBatch = "<Method ID='1' Cmd='Update'>" + _
                        "<Field Name = 'ID'>" & sFileIDinList & "</Field>" + _
                        "<Field Name = 'FileRef'>" & sFinalFilePath & "</Field>" + _
                        "<Field Name = 'TestCol'>" & sTestCol & "</Field>" + _
                        "</Method>"
                    Dim xmlDoc = New System.Xml.XmlDocument
                    Dim elBatch As System.Xml.XmlElement = xmlDoc.createelement("Batch")
                    elBatch.InnerXml = strBatch
                    Dim ndreturn As System.Xml.XmlNode = listService.UpdateListItems(sDocLib, elBatch)
                End If
                Return "TRUE"
            Catch ex As Exception
                Return ex.Message
            End Try
        End Function
    Private Function sGetID(ByVal sURL As String, ByVal sListGUID As String, ByVal sFileName As String) As String
            Dim sUser As String = ConfigurationManager.AppSettings("User")
            Dim sPwd As String = ConfigurationManager.AppSettings("Pwd")
            Dim sDomain As String = ConfigurationManager.AppSettings("Domain")
            Dim netAccess As System.Net.NetworkCredential = New System.Net.NetworkCredential(sUser, sPwd, sDomain)
            Dim L As New SPLists.Lists
            L.Credentials = netAccess
            L.Url = sURL
            Dim xmldoc As XmlDocument = New XmlDocument
            Dim query As XmlNode = xmldoc.CreateNode(XmlNodeType.Element, "Query", "")
            query.InnerXml = "<OrderBy><FieldRef Name='Modified'  Ascending='False'></FieldRef></OrderBy>"""
            Try
                Dim caml As XmlNode = L.GetListItems(sListGUID, Nothing, query, Nothing, "1", Nothing)
                Dim id As String = caml.ChildNodes(1).ChildNodes(1).Attributes("ows_ID").Value
                Return id
            Catch ex As Exception
                Return ex.Message
            End Try
        End Function
