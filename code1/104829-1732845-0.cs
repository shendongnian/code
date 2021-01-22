    private ToolTip     _toolTip = new ToolTip();
    private Control     _currentToolTipControl = null; 
    public Form1()
    {
        InitializeComponent();
    
        _toolTip.SetToolTip(this.button1, "My button1");
        _toolTip.SetToolTip(this.button2, "My button2");
        _toolTip.SetToolTip(this.textBox1, "My text box");
    }
    
    private void Form1_MouseMove(object sender, MouseEventArgs e)
    {
        Control control = GetChildAtPoint(e.Location);
        if (control != null)
        {
            if (!control.Enabled && _currentToolTipControl == null)
            {
                string toolTipString = _toolTip.GetToolTip(control);
                // trigger the tooltip with no delay and some basic positioning just to give you an idea
                _toolTip.Show(toolTipString, control, control.Width/2, control.Height/2);
                _currentToolTipControl = control;
            }
        }
        else
        {
            if (_currentToolTipControl != null) _toolTip.Hide(_currentToolTipControl);
            _currentToolTipControl = null;
        }
    }
