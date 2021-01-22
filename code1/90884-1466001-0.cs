    using System;
    using PdfSharp.Pdf;
    using PdfSharp.Pdf.IO;
    
    namespace ConsoleApplication1
    {
      class Program
      {
        static void Main (string[] args)
        {
          Program p = new Program();
          p.Test();
    
        }
    
        public void Test ()
        {
          PdfDocument document = PdfReader.Open ("Test.pdf");
    
          document.Info.Author = "ME";
    
          document.Save ("Result");
        }
      }
}
