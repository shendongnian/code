    // Global Variables
    private int _xPos;
    private int _yPos;
    private bool _dragging;
    
    // Register mouse events
    pictureBox.MouseUp += (sender, args) =>
    {
        var c = sender as PictureBox;
        if (null == c) return;
        _dragging = false;
    };
    
    pictureBox.MouseDown += (sender, args) =>
    {
        if (args.Button != MouseButtons.Left) return;
        _dragging = true;
        _xPos = args.X;
        _yPos = args.Y;
    };
    
    pictureBox.MouseMove += (sender, args) =>
    {
        var c = sender as PictureBox;
        if (!_dragging || null == c) return;
        c.Top = args.Y + c.Top - _yPos;
        c.Left = args.X + c.Left - _xPos;
    };
