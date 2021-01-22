    foreach (FontFamily ff in System.Drawing.FontFamily.Families)
    {
        if (ff.IsStyleAvailable(FontStyle.Regular))
        {
            Font font = new Font(ff, 10);
            LOGFONT lf = new LOGFONT();
            font.ToLogFont(lf);
            if (lf.lfPitchAndFamily ^ 1)
            {
                do stuff here......
            }
        }
    }
