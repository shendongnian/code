    protected override void OnResizeEnd(EventArgs e)
            {
                if (_isNegative)
                {
                    Location = _negative;
                }
                oldRight = this.Right;
                oldBottom = this.Bottom;
                //base.OnResizeEnd(e);
            }
    
            protected override void OnMove(EventArgs e)
            {
                if ( this.Right == oldRight || this.Bottom == oldBottom)
                    return;
                if (Location.Y < 0)
                {
                    _isNegative = true;
                    _negative = Location;
    
                }
                else
                {
                    _isNegative = false;
                }
                //base.OnMove(e);
               
                
            }
 
    
