    using OpenHtmlToPdf;
    using System.IO;
    namespace Test{
        class TestOpenHTMLtoPDF{
             private void Main(){
                 string html = "<html><body><h1>TEST</h1></body></html>";
                 var pdf = Pdf.From(html).OfSize(size);
                 byte[] content = pdf.Content();
                 File.WriteAllBytes("C:\\Test.pdf", content);
             }
        }
    }
    
