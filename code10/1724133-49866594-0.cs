    public class MyLocationTextExtractionStrategy : LocationTextExtractionStrategy
    {
        public override void EventOccurred(IEventData data, EventType type)
        {
            if (data is TextRenderInfo renderInfo)
            {
                var oFont = renderInfo.GetFont();
                PdfDictionary fontDescriptor = oFont.GetPdfObject().GetAsDictionary(PdfName.FontDescriptor);
                PdfNumber number = fontDescriptor?.GetAsNumber(PdfName.FontWeight);
                double? weight = number?.GetValue();
                [... process weight, it is null if not set in the descriptor ...]
            }
            base.EventOccurred(data, type);
        }
    }
