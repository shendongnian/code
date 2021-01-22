    // 'PrivateFontCollection' is in the 'System.Drawing.Text' namespace
    var foo = new PrivateFontCollection();
    // Provide the path to the font on the filesystem
    foo.AddFontFile("...");
    var myCustomFont = new Font((FontFamily)foo.Families[0], 36f);
