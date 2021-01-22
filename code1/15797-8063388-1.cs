            <HttpPost()> _
        Public Function Upload(uploadedFile As System.Web.HttpPostedFileBase) As ActionResult
            If uploadedFile IsNot Nothing Then 
                If uploadedFile.ContentLength > 0 Then
                 
                   Dim mimeType As String = Nothing 
                    'Upload
                    Dim PathFileName As String = System.IO.Path.GetFileName(uploadedFile.FileName)
        
                     Dim path = System.IO.Path.Combine(Server.MapPath("~/App_Data/Uploads"), PathFileName)
                 
                    If Not System.IO.Directory.Exists(Path) Then
                        System.IO.Directory.CreateDirectory(Path)
                    End If
                    Dim firstLoop As Boolean = True
                    uploadedFile.SaveAs(path)                  
                 Next
            End If
            Return Nothing
        End Function
