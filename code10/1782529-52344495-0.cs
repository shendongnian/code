  <PackageReference Include="System.Text.Encoding.CodePages" />
And here is a snippet example of a working creation of a font from a URL added to a cell text.
    using System;
    using System.Net;
    
    using iTextSharp.text;
    using iTextSharp.text.pdf;
    
    namespace MyNameSpace
    {
      class Foo
      {
        public static PdfPCell CreateCellWithFontFromUrl()
        {
    
          // Necesary ONLY if you're getting the error `not supported encoding`
          System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
    
          string fontUri ="http://www.fonts.com/yourfontname.ttf";
          byte[] fontBinary = new WebClient().DownloadData(fontUri);
    
          BaseFont bf = BaseFont.CreateFont(
            "VAGRoundedStd-Thin.ttf", // Is important you add ".ttf" at the end of the font name
            BaseFont.WINANSI,
            BaseFont.EMBEDDED,
            false, // NO CACHE
            fontBinary,
            null
          );
    
          return bf;
        };
    
        Font MY_FONT = new Font(bf, 20, Font.BOLD, new Color(29, 29, 29));
        PdfPCell cell = new PdfPCell(new Paragraph("text of the paragraph", MY_FONT));
    
        return cell;
      }
    }
