    //warning: incomplete, add error checking etc
    private readonly VisualStyleElement element = VisualStyleElement.Tab.Body.Normal;
    public bool UseVisbleBackgroundStyle { get; set; }
    protected override void OnPaint(PaintEventArgs pe)
    {
        if (UseVisbleBackgroundStyle)
        {
            var x = new VisualStyleRenderer(element);                           
            x.DrawBackground(pe.Graphics, this.ClientRectangle);
        }
        else
        {
            base.OnPaint(pe);
        }
    }
