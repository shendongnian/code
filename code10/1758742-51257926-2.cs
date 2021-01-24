    private void ellipse_MouseDown(object sender, MouseButtonEventArgs e)
    {
        //Get the x,y position as relative to the upper-left corner of the overlay
        var point = e.GetPosition(sender as IInputElement); 
        
        //Or, relative to the wheel
        var point2 = e.GetPosition(image);
    }
