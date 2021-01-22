    If Not IsPostBack Then
                Dim sBasePath As String = System.Web.HttpContext.Current.Request.ServerVariables("APPL_PHYSICAL_PATH")
                If sBasePath.EndsWith("\") Then
                    sBasePath = sBasePath.Substring(0, sBasePath.Length - 1)
                End If
                sBasePath = sBasePath & "\" & "pics" & "\" & lblID.Text
                Dim oList As New System.Collections.Generic.List(Of String)()
                For Each s As String In System.IO.Directory.GetFiles(sBasePath, "*_logo.*")
                    'We could do some filtering for example only adding .jpg or something 
                    oList.Add(System.IO.Path.GetFileName(s))
                Next
                If oList.Count = 0 Then
                  oList.Add("Path to a image with no image text")
                 
                End If
	   repImages.DataSource = oList
                    repImages.DataBind()
            End If
