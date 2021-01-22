    public Image HoverImage { get; set; }
    public Image PlainImage { get; set; }
    public Image PressedImage { get; set; }
    protected override void OnMouseEnter(System.EventArgs e)
    {
      base.OnMouseEnter(e);
      if (HoverImage == null) return;
      if (PlainImage == null) PlainImage = base.Image;
      base.Image = HoverImage;
    }
    protected override void OnMouseLeave(System.EventArgs e)
    {
      base.OnMouseLeave(e);
      if (HoverImage == null) return;
      base.Image = PlainImage;
    }
    protected override void OnMouseDown(MouseEventArgs e)
    {
      base.OnMouseDown(e);
      if (PressedImage == null) return;
      if (PlainImage == null) PlainImage = base.Image;
      base.Image = PressedImage;
    }
