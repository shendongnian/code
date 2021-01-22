        /// <summary>
        /// Sets the font size so the text is as large as possible while still fitting in the text
        /// area with out any scrollbars.
        /// </summary>
        public void ScaleFontToFit()
        {
            int fontSize = 10;
            const int incrementDelta = 5;
            const int decrementDelta = 1;
            this.SuspendLayout();
            // First we set the font size to the minimum.  We assume at the minimum size no scrollbars will be visible.
            SetFontSize(MinimumFontSize);
            // Next, we increment font size until it doesn't fit (or max font size is reached).
            for (fontSize = MinFontSize; fontSize < MaxFontSize; fontSize += incrementDelta)
            {
                SetFontSize(fontSize);
                if (!DoesTextFit())
                {
                    //Console.WriteLine("Text Doesn't fit at fontsize = " + fontSize);
                    break;
                }
            }
            // Finally, we keep decreasing the font size until it fits again.
            for (; fontSize > MinFontSize && !DoesTextFit(); fontSize -= decrementDelta)
            {
                SetFontSize(fontSize);
            }
            this.ResumeLayout();
        }
        #region Private Methods
        private bool VScrollVisible
        {
            get
            {
                Rectangle clientRectangle = this.ClientRectangle;
                Size size = this.Size;
                return (size.Width - clientRectangle.Width) >= SystemInformation.VerticalScrollBarWidth;
            }
        }
        /**
         * returns true when the Text no longer fits in the bounds of this control without scrollbars.
        */
        private bool DoesTextFit()
        {
                if (VScrollVisible)
                {
                    //Console.WriteLine("#1 Vscroll is visible");
                    return false;
                }
                // Special logic to handle the single line case... When multiline is false, we cannot rely on scrollbars so alternate methods.
                if (this.Multiline == false)
                {
                    Graphics graphics = this.CreateGraphics();
                    Size stringSize = graphics.MeasureString(this.Text, this.SelectionFont).ToSize();
                    //Console.WriteLine("String Width/Height: " + stringSize.Width + " " + stringSize.Height + "form... " + this.Width + " " + this.Height);
                    if (stringSize.Width > this.Width)
                    {
                        //Console.WriteLine("#2 Text Width is too big");
                        return false;
                    }
                    if (stringSize.Height > this.Height)
                    {
                        //Console.WriteLine("#3 Text Height is too big");
                        return false;
                    }
                    
                    if (this.Lines.Length > 1)
                    {
                        //Console.WriteLine("#4 " + this.Lines[0] + " (2): " + this.Lines[1]); // I believe this condition could be removed.
                        return false;
                    }
                }
                return true;
        }
        private void SetFontSize(int pFontSize)
        {
            SetFontSize((float)pFontSize);
        }
        private void SetFontSize(float pFontSize)
        {
            this.SelectAll();
            this.SelectionFont = new Font(this.SelectionFont.FontFamily, pFontSize, this.SelectionFont.Style);
            this.SelectionAlignment = HorizontalAlignment;
            this.Select(0, 0);
        }
        #endregion
