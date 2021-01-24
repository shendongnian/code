    public class Border : PdfPageEventHelper
    {
        public override void OnEndPage(PdfWriter Writer, Document Doc)
        {
            PdfContentByte content = Writer.DirectContent;
            Rectangle rectangle = new Rectangle(Doc.PageSize);
            rectangle.Left += Doc.LeftMargin;
            rectangle.Right -= Doc.RightMargin;
            rectangle.Top -= Doc.TopMargin;
            rectangle.Bottom += Doc.BottomMargin;
            content.SetColorStroke(BaseColor.BLACK);
            content.Rectangle(rectangle.Left, rectangle.Bottom, rectangle.Width, rectangle.Height);
            content.Stroke();
        }
    }
