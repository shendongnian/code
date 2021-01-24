    private async void canvas_Draw(Microsoft.Graphics.Canvas.UI.Xaml.CanvasControl sender, 
        Microsoft.Graphics.Canvas.UI.Xaml.CanvasDrawEventArgs args)
    {
        using (CanvasBitmap bitmap = await CanvasBitmap.LoadAsync(sender, "Assets/image.jpg"))
        {
            CanvasImageBrush canvasImageBrush = new CanvasImageBrush(sender, bitmap);
            args.DrawingSession.FillEllipse(new System.Numerics.Vector2(100f), 100, 100, canvasImageBrush);
        }
    }
