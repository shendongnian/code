    ''' <summary>
    ''' Converts a DotNET class library to a COFF-based image containing the entire assembly
    ''' </summary>
    Public Shared Function ReadAssembly(ByVal iPath As String) As Byte()
      If (Not IO.File.Exists(iPath)) Then Return Nothing
      Try
        Dim file_info As New FileInfo(iPath)
        Dim file_byte(Convert.ToInt32(file_info.Length)) As Byte
        Dim file_stream As New FileStream(iPath, FileMode.Open)
        file_stream.Read(file_byte, 0, file_byte.Length)
        file_stream.Close()
        Return file_byte
      Catch ex As Exception
        Kernel.EH_LogServer.AddMessage("Assembly reading failed: " & ex.Message, EH_RuntimeMessageType.Error)
        Return Nothing
      End Try
    End Function
