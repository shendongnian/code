    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using iTextSharp.text.pdf;
    using iTextSharp.text.xml;
    namespace GetPages_PDF
    {
      class Program
    {
        static void Main(string[] args)
          {
           // Right side of equation is location of YOUR pdf file
            string ppath = "C:\\aworking\\Hawkins.pdf";
            PdfReader pdfReader = new PdfReader(ppath);
            int numberOfPages = pdfReader.NumberOfPages;
            Console.WriteLine(numberOfPages);
            Console.ReadLine();
          }
       }
    }
