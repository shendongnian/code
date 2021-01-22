    using System.Drawing;
    using Media = System.Windows.Media;
    
     Font font = new Font(new System.Drawing.FontFamily("Comic Sans MS"), 10);
                //option 1
                Media.FontFamily mfont = new Media.FontFamily(font.Name);
                //option 2 does the same thing
                Media.FontFamilyConverter conv = new Media.FontFamilyConverter();
                Media.FontFamily mfont1 = conv.ConvertFromString(font.Name) as Media.FontFamily;
                //option 3
                Media.FontFamily mfont2 = Media.Fonts.SystemFontFamilies.Where(x => x.Source == font.Name).FirstOrDefault();
