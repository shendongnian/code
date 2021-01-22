        Using conn As New System.Data.SqlClient.SqlConnection(connectionSTRING)
           Dim adapter As New System.Data.SqlClient.SqlDataAdapter(selectSTRING, conn)
           Dim DS As System.Data.DataSet = New System.Data.DataSet
           adapter.Fill(DS)
           Dim ba() As Byte = Text.Encoding.ASCII.GetBytes(DS.Tables(0).Rows(0)("RTF_Field").ToString())
           Dim ms As MemoryStream = New MemoryStream(ba)
           Dim fd As FlowDocument = New FlowDocument
           Dim tr As TextRange = New TextRange(fd.ContentStart, fd.ContentEnd)
           tr.Load(ms, System.Windows.DataFormats.Rtf)
           ms.Close()
                RichTextBox.Document = fd
            End Using
