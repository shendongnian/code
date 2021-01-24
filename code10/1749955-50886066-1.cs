    public UserControl1() {
        InitializeComponent();
        WireMouseEvents(this);
    }
    void WireMouseEvents(Control container) {
        foreach (Control c in container.Controls) {
            c.Click += (s, e) => OnClick(e);
            c.DoubleClick += (s, e) => OnDoubleClick(e);
            c.MouseHover += (s, e) => OnMouseHover(e);
            c.MouseClick += (s, e) => {
                var p = PointToThis((Control)s, e.Location);
                OnMouseClick(new MouseEventArgs(e.Button, e.Clicks, p.X, p.Y, e.Delta));
            };
            c.MouseDoubleClick += (s, e) => {
                var p = PointToThis((Control)s, e.Location);
                OnMouseDoubleClick(new MouseEventArgs(e.Button, e.Clicks, p.X, p.Y, e.Delta));
            };
            WireMouseEvents(c);
        };
    }
    Point PointToThis(Control c, Point p) {
        return PointToClient(c.PointToScreen(p));
    }
