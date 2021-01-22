    Private Function SendPDFToClient(ByVal sPDFfilePath As String, ByVal sFileName As String, ByRef oReturnException As System.Exception) As Integer
            ' variables
            Dim oMethodBase As MethodBase = MethodBase.GetCurrentMethod()
            Dim METHOD_NAME As String = oMethodBase.DeclaringType.ToString() & "." & oMethodBase.Name.ToString()
    
    
            Try
    
    
                Dim aa As AliasAccount = New AliasAccount("ASP.NET", "Uiop_4567")
    
                ' Begin Impersonation
                aa.BeginImpersonation()
    
    
                Dim fs As System.IO.FileStream
    
                Dim br As System.IO.BinaryReader
    
                fs = New System.IO.FileStream(sPDFfilePath, System.IO.FileMode.Open)
    
                br = New System.IO.BinaryReader(fs)
    
    
                Dim oByteArray As Byte() = br.ReadBytes(fs.Length - 1)
    
                br.Close()
    
    
                ' End of Impersonation
                aa.EndImpersonation()
    
    
    
    
    
                lblHiddenFileExist.Text = "File Exist=" & System.IO.File.Exists(sPDFfilePath) & ControlChars.NewLine _
                                            & " ByteArray Length=" & oByteArray.Length().ToString()
    
    
                HttpContext.Current.Response.Buffer = True
                HttpContext.Current.Response.Clear()
                HttpContext.Current.Response.ClearContent()
                HttpContext.Current.Response.ClearHeaders()
                HttpContext.Current.Response.ContentType = "application/pdf"
                HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" & sFileName)
                HttpContext.Current.Response.BinaryWrite(oByteArray)
                HttpContext.Current.Response.Flush()
                HttpContext.Current.Response.Close()
    
    
    
                ' success
                Return 0
            Catch exThreadAbort As Threading.ThreadAbortException
                ' do nothing
            Catch ex As Exception
                ' failure
                ex.Data.Add("METHOD_NAME", METHOD_NAME)
                oReturnException = ex
                Return -1
            End Try
        End Function
