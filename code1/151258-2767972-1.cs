    base.OnEndPage(writer, document);
            PdfContentByte cb = writer.DirectContent;
    
    
            ////making a line
            cb.MoveTo(15F, document.GetBottom(-15));
            cb.SetLineWidth(0.5F);
            cb.LineTo(document.GetRight(-10), document.GetBottom(-15));
            cb.Stroke();
    
     cb.BeginText();
        
                cb.SetTextMatrix(20, document.GetBottom(-30));
                BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252,  BaseFont.NOT_EMBEDDED);
                cb.SetFontAndSize(bf, 10);
