    public override Rectangle DisplayRectangle
    {
        get
        {
            return Rectangle.FromLTRB(base.DisplayRectangle.Left,
                base.DisplayRectangle.Top + Font.Height + 4,
                base.DisplayRectangle.Right,
                base.DisplayRectangle.Bottom);
        }
    }
