    // The standard combo box height is determined by the font. This means, if you want a large text box, you must use a large font.
    // In our class, ItemHeight will now determine the height of the combobox with no respect to the combobox font.
    // TextAlign can be used to align the text in the ComboBox
    class UKComboBox : ComboBox
    {
    
        private StringAlignment _textAlign = StringAlignment.Center;
        [Description("String Alignment")]
        [Category("CustomFonts")]
        [DefaultValue(typeof(StringAlignment))]
        public StringAlignment TextAlign
        {
            get { return _textAlign; }
            set
            {
                _textAlign = value;
            }
        }
    
        private int _textYOffset = 0;
        [Description("When using a non-centered TextAlign, you may want to use TextYOffset to manually center the Item text.")]
        [Category("CustomFonts")]
        [DefaultValue(typeof(int))]
        public int TextYOffset
        {
            get { return _textYOffset; }
            set
            {
                _textYOffset = value;
            }
        }
    
    
        public UKComboBox()
        {
                // Set OwnerDrawVariable to indicate we will manually draw all elements.
                this.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
                // DropDownList style required for selected item to respect our DrawItem customizations.
                this.DropDownStyle = ComboBoxStyle.DropDownList;
                // Hook into our DrawItem & MeasureItem events
                this.DrawItem +=
                    new DrawItemEventHandler(ComboBox_DrawItem);
                this.MeasureItem +=
                    new MeasureItemEventHandler(ComboBox_MeasureItem);
                
        }
    
        // Allow Combo Box to center aligned and manually draw our items
        private void ComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
    
    
            // Draw the background
            e.DrawBackground();
    
            // Draw the items
            if (e.Index >= 0)
            {
                // Set the string format to our desired format (Center, Near, Far)
                StringFormat sf = new StringFormat();
                sf.LineAlignment = _textAlign;
                sf.Alignment = _textAlign;
    
                // Set the brush the same as our ForeColour
                Brush brush = new SolidBrush(this.ForeColor);
    
                // If this item is selected, draw the highlight
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                    brush = SystemBrushes.HighlightText;
    
                // Draw our string including our offset.
                e.Graphics.DrawString(this.Items[e.Index].ToString(), this.Font, brush, 
                    new RectangleF(e.Bounds.X, e.Bounds.Y + _textYOffset, e.Bounds.Width, e.Bounds.Height), sf);
            }
                
        }
    
    
        // If you set the Draw property to DrawMode.OwnerDrawVariable, 
        // you must handle the MeasureItem event. This event handler 
        // will set the height and width of each item before it is drawn. 
        private void ComboBox_MeasureItem(object sender,System.Windows.Forms.MeasureItemEventArgs e)
        {
            // Custom heights per item index can be done here.
        }
    
    }
