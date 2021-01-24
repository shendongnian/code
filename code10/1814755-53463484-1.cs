    [Category("Custom")]
    [Browsable(true)]
    [Description("Sets the Hover color of the round button")]
    [Editor(typeof(System.Windows.Forms.Design.WindowsFormsComponentEditor), typeof(System.Drawing.Color))]
    public Color HoverColor
    {
        get
        {
            return this._hoverColor;
        }
        set
        {
            if( this._hoverColor != value )
            {
                this._hoverColor = value;
                this.Invalidate();
            } 
        }
    }
