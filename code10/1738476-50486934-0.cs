    protected class ImprovedVariableHeaderEventHandler : IEventHandler
    {
        Dictionary<PdfPage, String> headers = new Dictionary<PdfPage, string>();
        protected String header = "";
        public void setHeaderFor(String header, PdfPage page)
        {
            headers[page] = header;
        }
        public void HandleEvent(Event @event)
        {
            PdfDocumentEvent documentEvent = (PdfDocumentEvent)@event;
            PdfPage page = documentEvent.GetPage();
            if (headers.ContainsKey(page))
            {
                header = headers[page];
                headers.Remove(page);
            }
            new PdfCanvas(page)
                    .BeginText()
                    .SetFontAndSize(PdfFontFactory.CreateFont(StandardFonts.HELVETICA), 12)
                    .MoveText(450, 806)
                    .ShowText(header)
                    .EndText()
                    .Stroke();
        }
    }
