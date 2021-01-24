    class FontProgramRenderFilter : RenderFilter
    {
        public override bool AllowText(TextRenderInfo renderInfo)
        {
            DocumentFont font = renderInfo.GetFont();
            PdfDictionary fontDict = font.FontDictionary;
            PdfName subType = fontDict.GetAsName(PdfName.SUBTYPE);
            if (PdfName.TYPE0.Equals(subType))
            {
                PdfArray descendantFonts = fontDict.GetAsArray(PdfName.DESCENDANTFONTS);
                PdfDictionary descendantFont = descendantFonts[0] as PdfDictionary;
                PdfDictionary fontDescriptor = descendantFont.GetAsDict(PdfName.FONTDESCRIPTOR);
                PdfStream fontStream = fontDescriptor.GetAsStream(PdfName.FONTFILE2);
                byte[] fontData = PdfReader.GetStreamBytes((PRStream)fontStream);
                MemoryStream dataStream = new MemoryStream(fontData);
                dataStream.Position = 0;
                MemoryPackage memoryPackage = new MemoryPackage();
                Uri uri = memoryPackage.CreatePart(dataStream);
                GlyphTypeface glyphTypeface = new GlyphTypeface(uri);
                memoryPackage.DeletePart(uri);
                ICollection<string> names = glyphTypeface.FamilyNames.Values;
                return names.Where(name => name.Contains("Arial")).Count() > 0;
            }
            else
            {
                // analogous code for other font subtypes
                return false;
            }
        }
    }
