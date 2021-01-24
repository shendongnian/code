    using pp = Microsoft.Office.Interop.PowerPoint;
    using Microsoft.Office.Core;
    public static MsoTriState IsUnderlined(pp.Shape parShape)
    {
        int cntUnderline = 0;
        foreach (pp.TextRange textTR in parShape.TextFrame.TextRange.Runs())
        {
            if (textTR.Font.Underline == MsoTriState.msoTrue)
            {
                cntUnderline++;
            }
        }
        if (cntUnderline == 0)
        {
            //No Underline
            return MsoTriState.msoFalse;
        }
        else if (parShape.TextFrame.TextRange.Runs().Count == cntUnderline)
        {
            //All Underline
            return MsoTriState.msoTrue;
        }
        else if (parShape.TextFrame.TextRange.Runs().Count != cntUnderline)
        {
            //Mixed Underline
            return MsoTriState.msoTriStateMixed;
        }
        return MsoTriState.msoTriStateToggle; //Consider as error
    }
