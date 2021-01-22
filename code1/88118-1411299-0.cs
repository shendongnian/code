            private void addTextToPDF(string cmyk, int fs, string fontname, Double posx,
        Double posY, Double mWidth, Double mHeight, String text, Double hpos)
        {
            text = secure.reverseCleanup(text);
            int lettercount1 = 0;
            foreach (char c in text)
            { lettercount1 ++; }
            TheDoc.Color.String = cmyk;
            TheDoc.FontSize = fs;
            var theFont = fontname;
            TheDoc.Rect.Position(posx, posY);
            TheDoc.Rect.Width = mWidth;
            TheDoc.Rect.Height = mHeight;
            TheDoc.HPos = hpos;
            TheDoc.Font = TheDoc.EmbedFont(theFont, "Latin", false, true, true);
            int didwrite = TheDoc.AddText(text);
            string addedchars = TheDoc.GetInfo(didwrite, "Characters");
            var oldid = didwrite;
            if (addedchars != lettercount1.ToString())
                didwrite = 0;
            while (didwrite==0) // hits this if first run did not add text
            {
                TheDoc.Delete(oldid);
                fs = fs - 2;
                TheDoc.Color.String = cmyk;
                TheDoc.FontSize = fs;
                theFont = fontname;
                TheDoc.Rect.Position(posx, posY);
                TheDoc.Rect.Width = mWidth;
                TheDoc.Rect.Height = mHeight;
                TheDoc.HPos = hpos;
                TheDoc.Font = TheDoc.EmbedFont(theFont, "Latin", false, true, true);
                didwrite = TheDoc.AddText(secure.reverseCleanup(text));
                addedchars = TheDoc.GetInfo(didwrite, "Characters");
                oldid = didwrite;
                if (addedchars != lettercount1.ToString())
                    didwrite = 0;
            }
            
        }
        public byte[] convertPDFToImageStream()
        {
            byte[] jpgBytes = null;
            byte[] theData = null;
            theData = TheDoc.GetData();
            TheDoc.Clear();
            TheDoc.Read(theData);
            TheDoc.Rendering.DotsPerInch = getDPI();
            TheDoc.Rendering.ColorSpace = "RGB";
            jpgBytes = TheDoc.Rendering.GetData("preview.jpg");
            return jpgBytes;
         }
