using iTextSharp.text.pdf;
using System;
using System.IO;
namespace PDFSetOCGVisibility5
{
    class Program
    {
        static void Main(string[] args)
        {
            var src = @"c:\layer-example.pdf";
            var dest = @"c:\layer-example-out.pdf";
            var reader = new PdfReader(src);
            PdfStamper pdf = new PdfStamper(reader, new FileStream(dest, FileMode.Create));
            var layers = pdf.GetPdfLayers();
            foreach (var layer in layers)
            {
                var title = layer.Key;
                Console.WriteLine($"title: {title ?? "null"}");
                layer.Value.On = false;
            }
            pdf.Close();
            reader.Close();
        }
    }
}
It's working as expected, so this seems to be a regression in itext7
