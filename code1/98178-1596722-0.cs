    private readonly List<BrushWrapper> colors_;
    private BrushWrapper white_;
    public ColorViewModel()
    {
        colors_ = (from p in typeof(Brushes).GetProperties()
                   select new BrushWrapper {
                       Brush = (Brush)converter.ConvertFromString(p.Name)
                   }).ToList();
        white_ = colors_.Single(b => b.Brush.ToString() == "#FFFFFFFF");
    }
    public List<BrushWrapper> Colors
    {
        get { return colors_; }
    }
    public BrushWrapper White
    {
        get { return white_; }
        set
        {
            if (white_ != value)
                white_ = value;
        }
    }
