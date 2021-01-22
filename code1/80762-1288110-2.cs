    using System;
    using System.IO;
    using System.Windows;
    using System.Windows.Media.Imaging;
    using System.Drawing.Imaging;
    using Excel = Microsoft.Office.Interop.Excel;
    
    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Excel.Application excel = new Excel.Application();
            Excel.Workbook wkb = excel.Workbooks.Add(Type.Missing);
            Excel.Worksheet sheet = wkb.Worksheets[1] as Excel.Worksheet;
            Excel.Range range = sheet.Cells[1, 1] as Excel.Range;
            range.Formula = "Hello World";
    
            // copy as seen when printed
            range.CopyPicture(Excel.XlPictureAppearance.xlPrinter, Excel.XlCopyPictureFormat.xlPicture);
    
            // uncomment to copy as seen on screen
            //range.CopyPicture(Excel.XlPictureAppearance.xlScreen, Excel.XlCopyPictureFormat.xlBitmap);
    
            Console.WriteLine("Please enter a full file name to save the image from the Clipboard:");
            string fileName = Console.ReadLine();
            using (FileStream fileStream = new FileStream(fileName, FileMode.Create))
            {
                if (Clipboard.ContainsData(System.Windows.DataFormats.EnhancedMetafile))
                {
                    Metafile metafile = Clipboard.GetData(System.Windows.DataFormats.EnhancedMetafile) as Metafile;
                    metafile.Save(fileName);
                }
                else if (Clipboard.ContainsData(System.Windows.DataFormats.Bitmap))
                {
                    BitmapSource bitmapSource = Clipboard.GetData(System.Windows.DataFormats.Bitmap) as BitmapSource;
    
                    JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(bitmapSource));
                    encoder.QualityLevel = 100;
                    encoder.Save(fileStream);
                }
            }
            object objFalse = false;
            wkb.Close(objFalse, Type.Missing, Type.Missing);
            excel.Quit();
        }
    }
