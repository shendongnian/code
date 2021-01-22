    using System.Windows.Media;
    
    String fontFilePath = "PATH TO YOUR FONT";
    GlyphTypeface glyphTypeface = new GlyphTypeface(fontFileURI);
    String fontFamily = glyphTypeface.Win32FamilyNames[new System.Globalization.CultureInfo("en-us")];
    String fontFace = glyphTypeface.Win32FaceNames[new System.Globalization.CultureInfo("en-us")];
    
    Console.WriteLine("Font: " + fontFamily + " " + fontFace);
