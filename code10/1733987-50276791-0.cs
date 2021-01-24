    private ChartArea _area = null;
    private Point _chartMouseDownLocation;
    ...
    private void MainForm_Load(object sender, EventArgs e)
    {
        ...
        // Disable zooming by chart control because zoom is initiated by MouseUp event
        _area.AxisX.ScaleView.Zoomable = false;
        _area.AxisY.ScaleView.Zoomable = false;
        
        // Enable user selection to get the interval/rectangle of the selection for 
        // determining the interval for zooming
        _area.CursorX.IsUserSelectionEnabled = true;
        _area.CursorX.IntervalType = DateTimeIntervalType.Seconds;
        _area.CursorX.Interval = 1D;
        _area.CursorY.IsUserSelectionEnabled = true;
        _area.CursorY.Interval = 0;        
    }
    
    private void chart1_MouseDown(object sender, MouseEventArgs e)
    {
        _chartMouseDownLocation = e.Location;
    }
    private void chart1_MouseUp(object sender, MouseEventArgs e)
    {
        // Check if rectangle has at least 10 pixels wide and high
        if (Math.Abs(e.Location.X-_chartMouseDownLocation.X)>10 && Math.Abs(e.Location.Y - _chartMouseDownLocation.Y) > 10)
        {
            // Zoom to the Selection rectangle
            _area.AxisX.ScaleView.Zoom(
                Math.Min(_area.CursorX.SelectionStart, _area.CursorX.SelectionEnd),
                Math.Max(_area.CursorX.SelectionStart, _area.CursorX.SelectionEnd)
            );
            _area.AxisY.ScaleView.Zoom(
                Math.Min(_area.CursorY.SelectionStart, _area.CursorY.SelectionEnd),
                Math.Max(_area.CursorY.SelectionStart, _area.CursorY.SelectionEnd)
            );
        }
        // Reset/hide the selection rectangle
        _area.CursorX.SetSelectionPosition(0D, 0D);
        _area.CursorY.SetSelectionPosition(0D, 0D);
    }
