    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Media;
    
    namespace fontChecker
    {
        class Program
        {
            static void Main(string[] args)
            {
                var families = Fonts.GetFontFamilies(@"C:\WINDOWS\Fonts\Arial.TTF");
                foreach (FontFamily family in families)
                {
                    var typefaces = family.GetTypefaces();
                    foreach (Typeface typeface in typefaces)
                    {
                        GlyphTypeface glyph;
                        typeface.TryGetGlyphTypeface(out glyph);
                        IDictionary<int, ushort> characterMap = glyph.CharacterToGlyphMap;
    
                        foreach (KeyValuePair<int, ushort> kvp in characterMap)
                        {
                            Console.WriteLine(String.Format("{0}:{1}", kvp.Key, kvp.Value));
                        }
     
                    }
                }
            }
        }
    }
