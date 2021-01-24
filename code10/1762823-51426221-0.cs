    using System;
    using System.IO;
    using System.Linq;
    using PdfSharp.Pdf;
    using PdfSharp.Pdf.IO;
    
    namespace pdf_merger
    {
        class Program
        {
            static void Main(string[] args)
            {
                //files in files folder and named like: TP031041 TP031041 TP031337 TP031337_1
                var files = Directory.GetFiles("files", "*.pdf");
                var groups = files.GroupBy(n => n.Split('.')[0].Split('_')[0]);
    
                foreach (var items in groups)
                {
                    Console.WriteLine(items.Key);
                    PdfDocument outputPDFDocument = new PdfDocument();
                    foreach (var pdfFile in items)
                    {
                        Merge(outputPDFDocument, pdfFile);
                    }
    
                    outputPDFDocument.Save(items.Key.Replace("files", "files/compiled") + ".pdf");
                }
    
                Console.ReadKey();
            }
    
            private static void Merge(PdfDocument outputPDFDocument, string pdfFile)
            {
                PdfDocument inputPDFDocument = PdfReader.Open(pdfFile, PdfDocumentOpenMode.Import);
                outputPDFDocument.Version = inputPDFDocument.Version;
                foreach (PdfPage page in inputPDFDocument.Pages)
                {
                    outputPDFDocument.AddPage(page);
                }
            }
        }
    }
