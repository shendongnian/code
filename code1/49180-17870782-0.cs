    Public Shared Sub SaveUploadedFile(File As HttpPostedFile)
      Dim oFile As Db.File
      oFile = New Db.File
      oFile.Data = File.ToBytes
    End Sub
    <Extension()>
    Public Function ToBytes(File As HttpPostedFile) As Byte()
      ToBytes = New Byte(File.ContentLength - 1) {}
      Using oStream As Stream = File.InputStream
        oStream.Read(ToBytes, 0, File.ContentLength)
      End Using
    End Function
