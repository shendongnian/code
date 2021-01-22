    Public Class Video_File_Upload
        Implements System.Web.IHttpHandler
        'Dim File_Path_Chapter_Video As String = "XXX/"
        Dim Directory_Videos As String = System.Configuration.ConfigurationManager.AppSettings("Videos_Save")
        Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
            context.Response.ContentType = "text/plain"
            context.Response.Expires = -1
            Try
                Dim postedFile As HttpPostedFile = context.Request.Files("Filedata")
                Dim filename As String = postedFile.FileName
                'string folderName = context.Request.QueryString["FolderName"];
                Dim NOF As String
                Dim CheckFilePath As String
                Dim MapPath As String
                NOF = Convert.ToString(context.Request("NOF"))
                CheckFilePath = Directory_Videos & NOF
                If Directory.Exists(CheckFilePath) = False Then
                    Directory.CreateDirectory(CheckFilePath)
                End If
                MapPath = Directory_Videos & NOF & "/" & filename
                postedFile.SaveAs(MapPath)
            Catch
    
            End Try
        End Sub
    
        ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
            Get
                Return False
            End Get
        End Property
    
    End Class
