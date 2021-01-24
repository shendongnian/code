    Imports System.IO
    Imports iTextSharp.text
    Imports iTextSharp.tool.xml
    Imports iTextSharp.text.pdf
    Imports iTextSharp.tool.xml.parser
    Imports iTextSharp.tool.xml.pipeline.css
    Imports iTextSharp.tool.xml.pipeline.html
    Imports iTextSharp.tool.xml.pipeline.end
    Imports iTextSharp.tool.xml.html
    Imports System.Text.RegularExpressions
    
    Public Class Form1
    
        Dim dsktop As String = My.Computer.FileSystem.SpecialDirectories.Desktop
        Public Function GetFormattedHTML(str As String) As String
            'format images by changing > to />
            ' find all indxes of img using regex and lambda exprations '
            Dim indexofIMG() As Integer = Regex.Matches(str.ToString, "IMG", RegexOptions.IgnoreCase) _
            .Cast(Of Match)().Select(Function(x) x.Index).ToArray()
    
            ' check from each index of "IMG" if "/" is missing '
            For Each itm As Integer In indexofIMG
                Dim counter As Integer = itm
                While counter < str.ToString.Length - 1
                    If str(counter) = ">" Then
                        If str(counter - 1) <> "/" Then
                            ' fix the missing "/" using Insert() method '
                            str = str.ToString.Insert(counter, " /")
                        End If
                        Exit While
                    End If
                    counter += 1
                End While
            Next
            Return str.ToString
        End Function
        Private Sub btnEditHTML_Click(sender As Object, e As EventArgs) Handles btnEditHTML.Click
            Rtb.Text = String.Empty
            'the 2 base64 images in the html below are actually just small red dots
            Dim RawHTML As String = "<P>John Doe</P><IMG " &
            "src=""data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAYAAAAfFcSJAAAADUlEQVR42mP8z8BQDwAEhQGAhKmMIQAAAABJRU5ErkJggg=="">&nbsp;Jackson5<IMG " &
            "src=""data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAYAAAAfFcSJAAAADUlEQVR42mP8z8BQDwAEhQGAhKmMIQAAAABJRU5ErkJggg=="">"
            Rtb.Text = GetFormattedHTML(RawHTML)
            'notice that the 2nd base64 string is not edited as required. 
        End Sub
    
        Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
            'here I create a 2 column itextsharp table to parse my html into the cells
    
            Dim doc As New iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 25, 25, 25, 30)
            Dim wri As PdfWriter = PdfWriter.GetInstance(doc, New System.IO.FileStream(dsktop & "\testtable.pdf", System.IO.FileMode.Create))
            doc.Open()
            'set table columnwidths -------------------------------------------------------------
            Dim MainTable As New PdfPTable(2) '2 column table
            MainTable.WidthPercentage = 100
            Dim Wth(1) As Single
            Dim u As Integer = 2
            For i As Integer = 0 To 1
                Wth(i) = CInt(Math.Floor(2 * 500 / u))
            Next
            MainTable.SetWidths(Wth)
    
            Dim htmlstr As String = GetFormattedHTML("<P>John Doe</P><IMG " &
            "src=""data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAYAAAAfFcSJAAAADUlEQVR42mP8z8BQDwAEhQGAhKmMIQAAAABJRU5ErkJggg=="">&nbsp;Jackson5<IMG " &
            "src=""data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAYAAAAfFcSJAAAADUlEQVR42mP8z8BQDwAEhQGAhKmMIQAAAABJRU5ErkJggg=="">")
    
            Dim Elmts = New ElementList()
            Elmts = XMLWorkerHelper.ParseToElementList(htmlstr, Nothing)
            Dim MinorTable As New PdfPTable(1)
            MinorTable = SetTable(Elmts, htmlstr)
    
            For i = 1 To 2
                Dim Cell As New PdfPCell
                Cell.AddElement(MinorTable)
                MainTable.AddCell(Cell)
            Next
            doc.Add(MainTable)
            doc.Close()
    
            Process.Start(dsktop & "\testtable.pdf")
    
        End Sub
        Public Function SetTable(ByVal elements As ElementList, ByVal htmlcode As String) As PdfPTable
    
            Dim tagProcessors As DefaultTagProcessorFactory = CType(Tags.GetHtmlTagProcessorFactory(), DefaultTagProcessorFactory)
            tagProcessors.RemoveProcessor(HTML.Tag.IMG) ' remove the default processor
            tagProcessors.AddProcessor(HTML.Tag.IMG, New CustomImageTagProcessor()) ' use our new processor
    
            Dim cssResolver As ICSSResolver = XMLWorkerHelper.GetInstance().GetDefaultCssResolver(True)
            cssResolver.AddCssFile(Application.StartupPath & "\pdf.css", True)
            'see sample css file at https://learnwebcode.com/how-to-create-your-first-css-file/
    
            'Setup Fonts
            Dim xmlFontProvider As XMLWorkerFontProvider = New XMLWorkerFontProvider(XMLWorkerFontProvider.DONTLOOKFORFONTS)
            xmlFontProvider.RegisterDirectory(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets/fonts/"))
    
            Dim cssAppliers As CssAppliers = New CssAppliersImpl(xmlFontProvider)
    
            Dim htmlContext As HtmlPipelineContext = New HtmlPipelineContext(cssAppliers)
            htmlContext.SetAcceptUnknown(True)
            htmlContext.SetTagFactory(tagProcessors)
    
            Dim pdf As ElementHandlerPipeline = New ElementHandlerPipeline(elements, Nothing)
            Dim htmlp As HtmlPipeline = New HtmlPipeline(htmlContext, pdf)
            Dim css As CssResolverPipeline = New CssResolverPipeline(cssResolver, htmlp)
    
            Dim worker As XMLWorker = New XMLWorker(css, True)
            Dim p As XMLParser = New XMLParser(worker)
    
            'Dim holderTable As New PdfPTable({1})
            Dim holderTable As PdfPTable = New PdfPTable({1})
            holderTable.WidthPercentage = 100
            holderTable.HorizontalAlignment = Element.ALIGN_LEFT
    
            Dim holderCell As New PdfPCell()
            holderCell.Padding = 0
            holderCell.UseBorderPadding = False
            holderCell.Border = 0
    
            p.Parse(New MemoryStream(System.Text.Encoding.ASCII.GetBytes(htmlcode)))
    
            For Each el As IElement In elements
                holderCell.AddElement(el)
            Next
            holderTable.AddCell(holderCell)
            'Dim holderRow As New PdfPRow({holderCell})
            'holderTable.Rows.Add(holderRow)
            Return holderTable
    
        End Function
    
    End Class
    
    Public Class CustomImageTagProcessor
        Inherits iTextSharp.tool.xml.html.Image
        Public Overrides Function [End](ctx As IWorkerContext, tag As Tag, currentContent As IList(Of IElement)) As IList(Of IElement)
            Dim attributes As IDictionary(Of String, String) = tag.Attributes
            Dim src As String = String.Empty
            If Not attributes.TryGetValue(iTextSharp.tool.xml.html.HTML.Attribute.SRC, src) Then
                Return New List(Of IElement)(1)
            End If
    
            If String.IsNullOrEmpty(src) Then
                Return New List(Of IElement)(1)
            End If
    
            If src.StartsWith("data:image/", StringComparison.InvariantCultureIgnoreCase) Then
                ' data:[<MIME-type>][;charset=<encoding>][;base64],<data>
                Dim base64Data As String = src.Substring(src.IndexOf(",") + 1)
                Dim imagedata As Byte() = Convert.FromBase64String(base64Data)
                Dim image As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(imagedata)
    
                Dim list As List(Of IElement) = New List(Of IElement)()
                Dim htmlPipelineContext As pipeline.html.HtmlPipelineContext = GetHtmlPipelineContext(ctx)
                list.Add(GetCssAppliers().Apply(New Chunk(DirectCast(GetCssAppliers().Apply(image, tag, htmlPipelineContext), iTextSharp.text.Image), 0, 0, True), tag, htmlPipelineContext))
                Return list
            Else
                If File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, src)) Then
                    Dim imagedata As Byte() = File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, src))
                    Dim image As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, src))
    
                    Dim list As List(Of IElement) = New List(Of IElement)()
                    Dim htmlPipelineContext As pipeline.html.HtmlPipelineContext = GetHtmlPipelineContext(ctx)
                    list.Add(GetCssAppliers().Apply(New Chunk(DirectCast(GetCssAppliers().Apply(image, tag, htmlPipelineContext), iTextSharp.text.Image), 0, 0, True), tag, htmlPipelineContext))
                    Return list
                End If
                Return MyBase.[End](ctx, tag, currentContent)
            End If
        End Function
    End Class
