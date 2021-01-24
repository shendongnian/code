     public void FindTextInPdf(string SearchStr, string[] sources)
     {
   
                foreach (var item in sources)
                {
                    if (File.Exists(item))
                    {
                        using (PdfReader reader = new PdfReader(item))
                        using (var doc = new PdfDocument(reader))
                        {
                            var pageCount = doc.GetNumberOfPages();
                            for (int i = 1; i <= pageCount; i++)
                            {
                                PdfPage page = doc.GetPage(i);
                                var box = page.GetCropBox();
                                var rect = new Rectangle(box.GetX(), box.GetY(), box.GetWidth(), box.GetHeight());
                                var filter = new IEventFilter[1];
                                    filter[0] = new TextRegionEventFilter(rect);
                                ITextExtractionStrategy strategy = new FilteredTextEventListener(new TextLocationStrategy(), filter);
                                var str = PdfTextExtractor.GetTextFromPage(page, strategy);
                                if (str.Contains(SearchStr) == true)
                                {
                                    Console.WriteLine("Searched text found in file:[ " + item + " ] page : [ " + i + " ]");
                                }
                                foreach (var d in objectResult)
                                {
                                    Console.WriteLine("Char >"+ d.Text+ " X >"+ d.Rect.GetX()+" font >"+ d.FontFamily + " font size >"+ d.FontSize.ToString()+" space >"+ d.SpaceWidth);**
                                   
                                }
                            }
                        }
                    }
               
           
        }
    class TextLocationStrategy : LocationTextExtractionStrategy
    {
        public static List<TextMyChunk> objectResult = new List<TextMyChunk>();
        public class TextMyChunk
        {
            public string Text { get; set; }
            public Rectangle Rect { get; set; }
            public string FontFamily { get; set; }
            public float FontSize { get; set; }
            public float SpaceWidth { get; set; }
        }
        public override void EventOccurred(IEventData data, EventType type)
        {
            if (!type.Equals(EventType.RENDER_TEXT)) return;
            TextRenderInfo renderInfo = (TextRenderInfo)data;
   
            IList<TextRenderInfo> text = renderInfo.GetCharacterRenderInfos();
            foreach (TextRenderInfo t in text)
            {
                string letter = t.GetText();
                Vector letterStart = t.GetBaseline().GetStartPoint();
                Vector letterEnd = t.GetAscentLine().GetEndPoint();
                Rectangle letterRect = new Rectangle(letterStart.Get(0), letterStart.Get(1), letterEnd.Get(0) - letterStart.Get(0), letterEnd.Get(1) - letterStart.Get(1));
                    TextMyChunk chunk = new TextMyChunk();
                    chunk.Text = letter;
                    chunk.Rect = letterRect;
                    chunk.FontFamily = t.GetFont().GetFontProgram().ToString();
                    chunk.FontSize = t.GetFontSize();
                    chunk.SpaceWidth = t.GetSingleSpaceWidth();
    
                    objectResult.Add(chunk);
                
            }
        }
