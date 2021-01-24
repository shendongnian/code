    using iTextSharp.text.pdf;
    using iTextSharp.text.pdf.parser;
    using System;
    using System.Collections.Generic;
    using System.IO;
    
    namespace Itext5
    {
        class Program
        {
            static void Main(string[] args)
            {
                PdfReader reader = new PdfReader(@"D:\191.pdf");
                IEnumerable<string> GetColumnText(float llx, float lly, float urx, float ury)
    
                {
                    int get_PageNum = reader.NumberOfPages;
                    
                    for (int pagecount = 1; pagecount <= get_PageNum; pagecount++)
                    {
                        var rect = new iTextSharp.text.Rectangle(llx, lly, urx, ury);
                        var renderFilter = new RenderFilter[1];
                        renderFilter[0] = new RegionTextRenderFilter(rect);
                        var textExtractionStrategy = new FilteredTextRenderListener(new LocationTextExtractionStrategy(), renderFilter);
                        var text = PdfTextExtractor.GetTextFromPage(reader, pagecount, textExtractionStrategy);
                        yield return text;
                    }
                }
    
                foreach (string result in GetColumnText(0, 0, 500, 500000))
                {
                    Console.Write("{0} ", result);
                    Console.ReadLine();
                }
    
            }
        }
    }
