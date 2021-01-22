    PdfContentByte cb = writer.DirectContent;
            cb.BeginText();
    
            cb.SetTextMatrix(20, document.GetBottom(-30));
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bf, 10);
    
            //thats is the piece of code that makes problems
            //if i remove it then document displays without error
            cb.MoveTo(15F, document.GetBottom(-15));
            cb.SetLineWidth(0.5F);
            cb.LineTo(document.GetRight(0), document.GetBottom(-15));
            cb.Stroke();
