    public bool IsPdf(Stream stm)
    {
        stm.Seek(0, SeekOrigin.Begin);
        PdfToken token;
        while ((token = GetToken(stm)) != null) 
        {
            if (token.TokenType == MLPdfTokenType.Comment) 
            {
                if (token.Text.StartsWith("%PDF-1.")) 
                    return true;
            }
            if (stm.Position > 1024)
                break;
        }
        return false;
    }
