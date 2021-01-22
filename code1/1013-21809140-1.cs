    Private Sub btnCarga(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button1.Click
                             
        Dim archivoCarga As New StreamReader("prueba.rtf")
        With RichTextBox1
            .Selection.Select(.Document.ContentStart, RichTextBox1.Document.ContentEnd)
            .Selection.Load(archivoCarga.BaseStream, System.Windows.DataFormats.Rtf)
        End With
    End Sub
                             
    Private Sub btnGuarda(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button2.Click
                             
        Dim archivoSalida As New StreamWriter("prueba.rtf")
        Dim bs As Stream = archivoSalida.BaseStream
                            
        With RichTextBox1
            .Selection.Select(RichTextBox1.Document.ContentStart,     RichTextBox1.Document.ContentEnd)
            .Selection.Save(bs, System.Windows.DataFormats.Rtf)
        End With
    End Sub
