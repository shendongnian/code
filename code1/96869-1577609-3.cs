    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Text;
    using System.Windows.Forms;
    namespace XXX.UI.Custom
    {
    /// <summary>
    /// A label which is capable of subscript.
    /// 
    /// Version: 1.
    /// Author: XXX.
    /// Date: 15/10/2009.
    /// Changes: Initial version.
    /// </summary>
    public class SubscriptLabel : Label
    {
        #region Vars
        // Vars.
        private char _subMark = '`';
        private SolidBrush _brush = new SolidBrush(Color.Black);
        private StringFormat _stringFormat = new StringFormat(StringFormat.GenericTypographic);
        #endregion
        #region Properties
        /// <summary>
        /// Gets or sets the subscript marker.
        /// </summary>
        /// <value>The subscript marker.</value>
        [Description("Marker for start/end of subscript text."),
        Category("Appearance"),
        Browsable(true)]
        public char SubscriptMarker
        {
            get
            {
                return _subMark;
            }
            set
            {
                _subMark = value;
                Invalidate();
            }
        }
        #endregion
        #region Methods
        #region Public
        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptLabel"/> class.
        /// </summary>
        public SubscriptLabel()
        {
            // Setup text mode.
            _stringFormat.Alignment = StringAlignment.Near;
            _stringFormat.HotkeyPrefix = HotkeyPrefix.Show;
            _stringFormat.LineAlignment = StringAlignment.Near;
            _stringFormat.Trimming = StringTrimming.EllipsisCharacter;
            _stringFormat.FormatFlags = StringFormatFlags.MeasureTrailingSpaces | StringFormatFlags.DisplayFormatControl
                | StringFormatFlags.NoClip | StringFormatFlags.NoFontFallback
                | StringFormatFlags.NoWrap;
        }
        #endregion
        #region Private
        /// <summary>
        /// Measures the Y DSW.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="text">The text.</param>
        /// <param name="font">The font.</param>
        /// <returns>The size.</returns>
        private SizeF MeasureDSW(Graphics graphics, string text,
            Font font)
        {
            // Init.
            graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            // Vars.
            StringFormat stringFormat = new StringFormat(StringFormat.GenericTypographic);
            SizeF size = new SizeF();
            // Init.
            stringFormat.Alignment = StringAlignment.Near;
            stringFormat.HotkeyPrefix = HotkeyPrefix.Show;
            stringFormat.LineAlignment = StringAlignment.Near;
            stringFormat.Trimming = StringTrimming.None;
            stringFormat.HotkeyPrefix = HotkeyPrefix.None;
            stringFormat.FormatFlags = StringFormatFlags.MeasureTrailingSpaces | StringFormatFlags.NoClip
                | StringFormatFlags.NoWrap;
            // The string size.
            size = graphics.MeasureString(text, Font,
                Width, stringFormat);
            // Init.
            graphics.TextRenderingHint = TextRenderingHint.SystemDefault;
            return size;
        }
        /// <summary>
        /// The pain method.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs"/> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            // Ensure that we have some text to draw.
            if (!string.IsNullOrEmpty(Text))
            {
                // Init.
                float currentX = 0f;
                float currentY = 0f;
                string[] splittedText = Text.Split(SubscriptMarker);
                // Setup graphics.
                e.Graphics.CompositingQuality = CompositingQuality.Default;
                e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                e.Graphics.SmoothingMode = SmoothingMode.Default;
                e.Graphics.TextRenderingHint = TextRenderingHint.SystemDefault;
                e.Graphics.CompositingMode = CompositingMode.SourceOver;
                // Loop around the splitted text.
                for (int i = 0; i < splittedText.Length; i++)
                {
                    // Vars.
                    int drawSubscript = i % 2;
                    // Are we to draw the subscript?
                    if (drawSubscript > 0)
                    {
                        DrawText(e.Graphics, ref currentX,
                            ref currentY, splittedText,
                            i, true);
                    }
                    else // Don't draw the subscript?
                    {
                        DrawText(e.Graphics, ref currentX,
                            ref currentY, splittedText,
                            i, false);
                    }
                }
            }
        }
        /// <summary>
        /// Draws the text onto the control.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="currentX">The current X.</param>
        /// <param name="currentY">The current Y.</param>
        /// <param name="splittedText">The splitted text.</param>
        /// <param name="i">The current text array position.</param>
        /// <param name="isSubScript">if set to <c>true</c> [is sub script].</param>
        private void DrawText(Graphics graphics, ref float currentX,
            ref float currentY, string[] splittedText,
            int i, bool isSubScript)
        {
            // Vars.
            string[] words = splittedText[i].Split(' ');
            // Loop around all the words.
            foreach (string word in words)
            {
                // Vars.
                string newWord = word + " ";
                float nextPosWord = MeasureDSW(graphics, newWord,
                    Font).Width;
                // Are we on the final element?
                if (word == words[words.Length-1] && !isSubScript)
                {
                    // Remove the space.
                    newWord = newWord.Trim();
                    // Re-measure to remove the space.
                    nextPosWord = MeasureDSW(graphics, newWord,
                        Font).Width;
                }
                // Are we over the end of the label?
                if ((currentX + nextPosWord) > Width)
                {
                    // Add the Y coords.
                    currentY += MeasureDSW(graphics, newWord,
                        Font).Height;
                    // Reset the X coords.
                    currentX = 0;
                }
                // Vars.
                float newCurrentY = currentY;
                // Is this for the sub script characters?
                if (isSubScript)
                {
                    // Add offsets.
                    newCurrentY += 5 * graphics.DpiY / 96; ;
                }
                // Draw onto the control.
                graphics.DrawString(newWord, Font,
                    _brush, currentX, 
                    newCurrentY);
                // Add the size onto the X coords.
                currentX += nextPosWord;
            }
        }
        #endregion
        #endregion
    }
    }
