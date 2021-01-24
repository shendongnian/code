using Spire.Pdf;
using Spire.Pdf.General.Find;
using System.Drawing;
namespace HideText
{
    class Program
    {
        static void Main(string[] args)
        {
            //load PDF file
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(@"C:\Users\Administrator\Desktop\Example.pdf");
            //find all results where "Hello World" appears
            PdfTextFind[] finds = null;
            foreach (PdfPageBase page in doc.Pages)
            {
                finds = page.FindText("Hello World").Finds;               
            }
            //cover the specific result with white background color
            finds[0].ApplyRecoverString("", Color.White, false);
            //save to file
            doc.SaveToFile("output.pdf");
        }
    }
}
Result
[![enter image description here][1]][1]
  [1]: https://i.stack.imgur.com/uh88A.jpg
