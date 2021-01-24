    using iTextSharp.text.pdf;
    using iTextSharp.text.pdf.parser;
    using System.Drawing;
    using iTextSharp.text;
    namespace pdf_edit_work
    {
    /// <summary>
    /// Replace the text in PDF
    /// </summary>
    public class PDFEdit
    {
        /// <summary>
        /// Find the text and replace in PDF
        /// </summary>
        /// <param name="sourceFile">The source PDF file where text to be searched</param>
        /// <param name="descFile">The new destination PDF file which will be saved with replaced text</param>
        /// <param name="textToBeSearched">The text to be searched in the PDF</param>
        /// <param name="textToBeReplaced">The text to be replaced with</param>
        public void ReplaceTextInPDF(string sourceFile, string descFile, string textToBeSearched, string textToBeReplaced)
        {
            ReplaceText(textToBeSearched, textToBeReplaced, descFile, sourceFile);
        }
        private void ReplaceText(string textToBeSearched, string textToAdd, string outputFilePath, string inputFilePath)
        {
            try
            {
                using (Stream inputPdfStream = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                using (Stream outputPdfStream = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
                using (Stream outputPdfStream2 = new FileStream(outputFilePath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    //Opens the unmodified PDF for reading
                    PdfReader reader = new PdfReader(inputPdfStream);
                    //Creates a stamper to put an image on the original pdf
                    PdfStamper stamper = new PdfStamper(reader, outputPdfStream); //{ FormFlattening = true, FreeTextFlattening = true };
                    for (var i = 1; i <= reader.NumberOfPages; i++)
                    {
                        var tt = new MyLocationTextExtractionStrategy(textToBeSearched);
                        var ex = PdfTextExtractor.GetTextFromPage(reader, i, tt); // ex will be holding the text, although we just need the rectangles [RectAndText class objects]
                        foreach (var p in tt.myPoints)
                        {
                            //Creates an image that is the size i need to hide the text i'm interested in removing
                            Bitmap transparentBitmap = new Bitmap((int)p.Rect.Width, (int)p.Rect.Height);
                            transparentBitmap.MakeTransparent();
                            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(transparentBitmap, new BaseColor(255, 255, 255));
                            //Sets the position that the image needs to be placed (ie the location of the text to be removed)
                            image.SetAbsolutePosition(p.Rect.Left, (p.Rect.Top - 8));
                            //Adds the image to the output pdf
                            stamper.GetOverContent(i).AddImage(image, true); // i stands for the page no.
                            PdfContentByte cb = stamper.GetOverContent(i);
                            // select the font properties
                            BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                            cb.SetColorFill(BaseColor.BLACK);
                            cb.SetFontAndSize(bf, 7);
                            // write the text in the pdf content
                            cb.BeginText();
                            // put the alignment and coordinates here
                            cb.ShowTextAligned(1, textToAdd, p.Rect.Left + 10, p.Rect.Top - 6, 0);
                            cb.EndText();
                        }
                    }
                    //Creates the first copy of the outputted pdf
                    stamper.Close();
                }
            }
            catch (Exception ex)
            {
            }
        }
        public class RectAndText
        {
            public iTextSharp.text.Rectangle Rect;
            public String Text;
            public RectAndText(iTextSharp.text.Rectangle rect, String text)
            {
                this.Rect = rect;
                this.Text = text;
            }
        }
        public class MyLocationTextExtractionStrategy : LocationTextExtractionStrategy
        {
            //Hold each coordinate
            public List<RectAndText> myPoints = new List<RectAndText>();
            //The string that we're searching for
            public String TextToSearchFor { get; set; }
            //How to compare strings
            public System.Globalization.CompareOptions CompareOptions { get; set; }
            public MyLocationTextExtractionStrategy(String textToSearchFor, System.Globalization.CompareOptions compareOptions = System.Globalization.CompareOptions.None)
            {
                this.TextToSearchFor = textToSearchFor;
                this.CompareOptions = compareOptions;
            }
            //Automatically called for each chunk of text in the PDF
            public override void RenderText(TextRenderInfo renderInfo)
            {
                base.RenderText(renderInfo);
                //See if the current chunk contains the text
                var startPosition = System.Globalization.CultureInfo.CurrentCulture.CompareInfo.IndexOf(renderInfo.GetText(), this.TextToSearchFor, this.CompareOptions);
                //If not found bail
                if (startPosition < 0)
                {
                    return;
                }
                //Grab the individual characters
                var chars = renderInfo.GetCharacterRenderInfos().Skip(startPosition).Take(this.TextToSearchFor.Length).ToList();
                //Grab the first and last character
                var firstChar = chars.First();
                var lastChar = chars.Last();
                //Get the bounding box for the chunk of text
                var bottomLeft = firstChar.GetDescentLine().GetStartPoint();
                var topRight = lastChar.GetAscentLine().GetEndPoint();
                //Create a rectangle from it
                var rect = new iTextSharp.text.Rectangle(bottomLeft[Vector.I1], bottomLeft[Vector.I2], topRight[Vector.I1], topRight[Vector.I2]);
                //Add this to our main collection
                this.myPoints.Add(new RectAndText(rect, this.TextToSearchFor));
            }
        }
    }
    }
