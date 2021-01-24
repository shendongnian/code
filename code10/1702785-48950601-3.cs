    for(int i = -1; i <= 10; i++)
    {
        var lineStart = ToCanvasCoordinates(new SKPoint(0, i));
        var lineEnd = ToCanvasCoordinates(new SKPoint(1, i));
    
        canvas.DrawLine(lineStart, lineEnd, LineGreyPaint);
    
        var textPosition = GetLegendCoordinates(i);
    
        canvas.DrawText(i.ToString(), textPosition, TextStyleFillPaintX);
    }
