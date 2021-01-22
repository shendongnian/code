    Panel _currentlyMovingCard = null;
    Point _moveOrigin = Point.Empty;
    private void Card_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            _currentlyMovingCard = (Panel)sender;
            _moveOrigin = e.Location;
        }
    }
    
    private void Card_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left && _currentlyMovingCard != null)
        {
            // move the _currentlyMovingCard control
            _currentlyMovingCard.Location = new Point(
                _currentlyMovingCard.Left - _moveOrigin.X + e.X,
                _currentlyMovingCard.Top - _moveOrigin.Y + e.Y);
        }
    }
    
    private void Card_MouseUp(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left && _currentlyMovingCard != null)
        {
            _currentlyMovingCard = null;
        }
    }
