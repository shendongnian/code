    using( Graphics g = CreateGraphics() )
    {
        _dpiX = g.DpiX;
        _dpiY = g.DpiY; // In practice usually == dpiX
        _points = _dpiX / 72.0f; // There are 72 points per inch
    }
