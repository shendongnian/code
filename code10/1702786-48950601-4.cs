    private void DrawDataLine(SKPoint start, SKPoint end, SKPaint paint)
    {
        var startTransformed = ToCanvasCoordinates(start);
        var endTransformed = ToCanvasCoordinates(end);
        _canvas.DrawLine(startTransformed, endTransformed, paint);
    }
    
    private void DrawData(SKPaint paint)
    {
        for(int i=1; i<_data.Length; i++)
        {
            DrawDataLine(new SKPoint(data[i-1].X, data[i-1].Y), new SKPoint(data[i].X, data[i].Y)); // given that the objects in _data have the properties X and Y
        }
    }
