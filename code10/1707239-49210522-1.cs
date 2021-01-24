    using iText.IO.Font;
    using iText.IO.Image;
    using iText.IO.Source;
    using iText.IO.Util;
    using iText.Kernel.Font;
    using iText.Kernel.Pdf;
    using iText.Layout;
    using iText.Layout.Element;
    using iText.Layout.Properties;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace x_console
    {
        class Program
        {
            static void Main(string[] args)
            {
                PdfWriter writer = new PdfWriter("C:\\Users\\Bill\\Desktop\\out.pdf");
                PdfDocument pdf = new PdfDocument(writer);
                Document document = new Document(pdf);
    
                Uri tiffFqn = UrlUtil.ToURL("C:\\Users\\Bill\\Desktop\\Multipage Test Image.tif");
                IRandomAccessSource iRandomAccessSource = new RandomAccessSourceFactory().CreateSource(tiffFqn);
                RandomAccessFileOrArray randomAccessFileOrArray = new RandomAccessFileOrArray(iRandomAccessSource);
    
                int tiffPageCount = TiffImageData.GetNumberOfPages(randomAccessFileOrArray);
    
                for (int i = 1; i <= tiffPageCount; i++)
                {
                    Image tiffPage = new Image(ImageDataFactory.CreateTiff(tiffFqn, true, i, true));
                    document.Add(tiffPage);
                }
    
                document.Close();
            }
        }
    }
    
