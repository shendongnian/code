    protected class ImprovedVariableHeaderEventHandlerAlt : IEventHandler
    {
        Dictionary<PdfPage, String> headers = new Dictionary<PdfPage, string>();
        protected String header = "";
        public void addHeaderDetailFor(string header, PdfPage page)
        {
            if (headers.ContainsKey(page))
                headers[page] += ", " + header;
            else
                headers[page] = header;
        }
        public void HandleEvent(Event @event)
        {
            PdfDocumentEvent documentEvent = (PdfDocumentEvent)@event;
            PdfPage page = documentEvent.GetPage();
            if (headers.ContainsKey(page))
            {
                header = String.Format("THE FACTORS OF {0}", headers[page]);
                headers.Remove(page);
            }
            new PdfCanvas(page)
                    .BeginText()
                    .SetFontAndSize(PdfFontFactory.CreateFont(StandardFonts.HELVETICA), 12)
                    .MoveText(150, 806)
                    .ShowText(header)
                    .EndText()
                    .Stroke();
        }
    }
