using System;
using System.IO;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
namespace MigraDocTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var document = new Document();
            // initial page setup and declare the styles
            document.DefaultPageSetup.Orientation = Orientation.Landscape;
            var mainStyle = document.Styles[StyleNames.Normal];
            mainStyle.Font.Name = "Arial";
            const string TitleStyleName = "Title";
            var titleStyle = document.Styles.AddStyle(TitleStyleName, StyleNames.Normal);
            titleStyle.ParagraphFormat.Font.Size = 12;
            titleStyle.ParagraphFormat.SpaceAfter = "0";
            titleStyle.Font.Bold = true;
            // main page section setup
            var section = document.AddSection();
            section.PageSetup.PageFormat = PageFormat.A4;
            section.PageSetup.Orientation = Orientation.Landscape;
            section.PageSetup.LeftMargin = "15mm";
            section.PageSetup.RightMargin = "15mm";
            section.PageSetup.TopMargin = "12mm";
            section.PageSetup.BottomMargin = "20mm";
            // add content to DOM here
            section.AddParagraph("Hello, world!").Style = TitleStyleName;
            // actually print document to PDF
            var pdfRenderer = new PdfDocumentRenderer(unicode: true) { Document = document };
            pdfRenderer.RenderDocument();
            using (var stream = new MemoryStream())
            {
                pdfRenderer.Save(stream, closeStream: false);
                File.WriteAllBytes(@"_output.pdf", stream.ToArray());
            }
        }
    }
}
Note, that MigraDoc nuget supports .NET Framework 2+, .NETStandard is not supported. So, you need targeting to full .NET Framework to use this libraries.
