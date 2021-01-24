    private async void canvas_Draw(Microsoft.Graphics.Canvas.UI.Xaml.CanvasControl sender, 
        Microsoft.Graphics.Canvas.UI.Xaml.CanvasDrawEventArgs args)
    {
        using (CanvasBitmap bitmap = await CanvasBitmap.LoadAsync(sender, "Assets/image.jpg"))
        {
            CanvasImageBrush canvasImageBrush = new CanvasImageBrush(sender, bitmap);
            System.Numerics.Vector2 center = new System.Numerics.Vector2((float)(bitmap.Size.Width / 2),
                (float)(bitmap.Size.Height / 2));
            canvasImageBrush.Transform = System.Numerics.Matrix3x2.CreateScale(0.5F, center);
            args.DrawingSession.FillEllipse(center, 160, 160, canvasImageBrush);
        }
    }
