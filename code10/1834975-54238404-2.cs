    internal class ReportsBrushes
    {
        public ReportsBrushes() : this(Color.White, Color.Black) { }
        public ReportsBrushes(Color ItemBackColor, Color ItemForeColor)
        {
            this.StandardForeground = new SolidBrush(ItemForeColor);
            this.StandardBackground = new SolidBrush(ItemBackColor);
        }
        public SolidBrush StandardForeground { get; set; }
        public SolidBrush StandardBackground { get; set; }
        public SolidBrush SelectedForeground { get ; set ; } = 
            new SolidBrush(Color.FromKnownColor(KnownColor.HighlightText));
        public SolidBrush SelectedBackground { get; set; } = 
            new SolidBrush(Color.FromKnownColor(KnownColor.Highlight));
        public SolidBrush SuccessBackground { get; set; } = 
            new SolidBrush(Color.LimeGreen);
        public SolidBrush ErrorBackground { get; set; } = 
            new SolidBrush(Color.OrangeRed);
        public (SolidBrush ForeColor, SolidBrush BackColor) GetItemBrushes(string ItemText, bool ItemSelected)
        {
            if (ItemSelected)
                return (this.SelectedForeground, this.SelectedBackground);
            else
            {
                if (ItemText.Contains("Success"))
                    return (this.StandardForeground, this.SuccessBackground);
                if (ItemText.Contains("Error"))
                    return (this.StandardForeground, this.ErrorBackground);
                return (this.StandardForeground, this.StandardBackground);
            }
        }
    }
