    string position = String.Empty;
    Point mouseDownPosition = new Point();
    
    private void myForm_MouseDown(object sender, MouseEventArgs e)
    {
        position = (e.X == 0) ? "Left" : ((e.X == myForm.Width) ? "Right" : String.Empty;
        position += (e.Y == 0) ? "Top" : ((e.Y == myForm.Height) ? "Bottom" : String.Empty;
        if(position != String.Empty)
        {
            mouseDownPosition = e.Location;
        }
    }
    
    private void myForm_MouseMove(object sender, MouseEventArgs e)
    {
        if(position != String.Empty)
        {        
            Point movementOffset = new Point(e.Location.X - mouseDownPosition.X, e.Location.Y - mouseDownPosition.Y);
            Switch(position)
            {
                Case "LeftTop":
                    myForm.Location.X += movementOffset.X;
                    myForm.Location.Y += movementOffset.Y;
                    myForm.Width -= movementOffset.X;
                    myForm.Height -= movementOffset.Y;
                Case "Left":
                    myForm.Location.X += movementOffset.X;
                    myForm.Width -= movementOffset.X;
                // Complete the remaining please :)
            }
        }
    }
    private void myForm_MouseUp(object sender, MouseEventArgs e)
    {
        position = String.Empty;
    }
