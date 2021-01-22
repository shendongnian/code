    private void HandleLeftMouseDown(MouseButtonEventArgs eventargs)
    {
        //Calculate the center point of selected object
        //...
        //assuming Point1 is the top left point
        var xCenter = (_selectedObject.Point2.X - _selectedObject.Point1.X) / 2 + _selectedObject.Point1.X
        var yCenter = (_selectedObject.Point2.Y - _selectedObject.Point1.Y) / 2 + _selectedObject.Point1.Y
        _selectedObjectCenterPoint = new Point((double) xCenter, (double) yCenter);
    
        //init set of last mouse over step with the mouse click point
         var clickPoint = eventargs.GetPosition(source);
        _lastMouseOverPoint = new Point(clickPoint.X,clickPoint.Y);
    }
    private void HandleMouseMove(MouseEventArgs eventArgs)
    {
        Point pointMouseOver = eventArgs.GetPosition(_source);                            
        //Get the difference to the last mouse over point
        var xd = pointMouseOver.X - _lastMouseOverPoint.X;
        var yd = pointMouseOver.Y - _lastMouseOverPoint.Y;
        // the direction depends on the current mouse over position in relation to the center point of the shape
        if (pointMouseOver.X < _selectedObjectCenterPoint.X)
            yd *= -1;
        if (pointMouseOver.Y > _selectedObjectCenterPoint.Y)
            xd *= -1;
            
        //add to the existing Angle   
        //not necessary to calculate the degree measure
        _selectedObject.Angle += (xd + yd);
                
        //save mouse over point            
        _lastMouseOverPoint = new Point(pointMouseOver.X, pointMouseOver.Y);
    }
