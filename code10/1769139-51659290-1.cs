        Public Function ImprimirCarnetPDF(ID As String) As ActionResult
            Dim converter As New HtmlToPdf()
            Dim doc As PdfDocument
            Dim Uri = New Uri(Request.Url.AbsoluteUri)
            Dim path = Uri.Scheme + "://" + Uri.Authority + "/WebForm1.aspx?usrid=" & ID
            doc = converter.ConvertUrl(path)
            Dim pdf As Byte() = doc.Save()
            doc.Close()
            Dim fileResult As FileResult = New FileContentResult(pdf, "application/pdf")
            fileResult.FileDownloadName = ID & "Document.pdf"
            Return fileResult
        End Function
