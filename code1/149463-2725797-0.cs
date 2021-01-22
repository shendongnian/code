    using System;
    using org.pdfbox.pdmodel;
    using org.pdfbox.util;
 
    namespace PDFReader
    {
    class Program
    {
        static void Main(string[] args)
        {
            PDDocument doc = PDDocument.load("lopreacamasa.pdf");
            PDFTextStripper pdfStripper = new PDFTextStripper();
            Console.Write(pdfStripper.getText(doc));
        }
    }
    }
