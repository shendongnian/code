    Protected WithEvents File1 As HtmlInputFile
    Dim vdestino As String = "\\centappd20nd01\uploads_avisos"
    Dim vtemporal As String = "c:\pdf"
    Protected WithEvents boton1 As Button
    Protected WithEvents usuario As TextBox
    Protected WithEvents contra As TextBox
    Protected WithEvents dominio As TextBox
    Protected WithEvents destino As TextBox
    Protected WithEvents origen As TextBox
    Protected WithEvents temporal As TextBox
    Protected WithEvents log As TextBox
    'Render this Web Part to the output parameter specified.
    Protected Overrides Sub RenderWebPart(ByVal output As System.Web.UI.HtmlTextWriter)
        log.RenderControl(output)
        output.Write("<br><font>Ruta Origen</font><br>")
        File1.RenderControl(output)
        output.Write("<br><font>Ruta Temporal </font><br>")
        temporal.RenderControl(output)
        output.Write("<br><font>Ruta Destino </font><br>")
        destino.RenderControl(output)
        output.Write("<br><font>Usuario </font><br>")
        usuario.RenderControl(output)
        output.Write("<br><font>Contraseña </font><br>")
        contra.RenderControl(output)
        output.Write("<br><font>Dominio </font><br>")
        dominio.RenderControl(output)
        output.Write("<br><br><center>")
        boton1.RenderControl(output)
        output.Write("</center>")
    End Sub
    Protected Overrides Sub CreateChildControls()
        dominio = New TextBox
        With dominio
            .Text = "admon-cfnavarra"
            .Width = Unit.Pixel("255")
        End With
        Controls.Add(dominio)
        boton1 = New Button
        With boton1
            .Text = "Copiar Fichero"
        End With
        Controls.Add(boton1)
        File1 = New HtmlInputFile
        With File1
        End With
        Controls.Add(File1)
        usuario = New TextBox
        With usuario
            .Text = "SVCWSINCPre_SNS"
            .Width = Unit.Pixel("255")
        End With
        Controls.Add(usuario)
        contra = New TextBox
        With contra
            .Text = "SVCWSINCPre_SNS"
            .Width = Unit.Pixel("255")
        End With
        Controls.Add(contra)
        destino = New TextBox
        With destino
            .Text = vdestino
            .Width = Unit.Pixel("255")
        End With
        Controls.Add(destino)
        log = New TextBox
        With log
            .Width = Unit.Percentage(100)
            .BackColor = System.Drawing.Color.Black
            .ForeColor = System.Drawing.Color.White
        End With
        Controls.Add(log)
        temporal = New TextBox
        With temporal
            .Text = vtemporal
            .Width = Unit.Pixel("255")
        End With
        Controls.Add(temporal)
    End Sub
    Private Sub boton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles boton1.Click
        If File1.PostedFile.FileName <> "" Then
            Dim _objContext As WindowsImpersonationContext = Nothing
            log.Text = QuienSoy()
            CopyFile(File1.PostedFile.FileName, temporal.Text)
            _objContext = Impersonalizacion.WinLogOn(usuario.Text, contra.Text, dominio.Text)
            CopyFile(temporal.Text & "\" & System.IO.Path.GetFileName(File1.PostedFile.FileName), destino.Text)
            _objContext.Undo()
        Else
            log.Text = "Se debe introducir un fichero"
        End If
    End Sub
    Friend Shared Function QuienSoy() As String
        Return WindowsIdentity.GetCurrent().Name
    End Function
    Public Function CopyFile(ByVal StartPath As String, ByVal EndPath As String)
        Try
            Dim fn As String = System.IO.Path.GetFileName(StartPath)
            System.IO.File.Copy(StartPath, EndPath & "\" & fn, False)
            log.Text = "Fichero Copiado Correctamente"
        Catch ex As Exception
            log.Text = ex.Message
        End Try
    End Function
