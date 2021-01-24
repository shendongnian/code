        using Microsoft.Graphics.Canvas;
        using Microsoft.Graphics.Canvas.Brushes;
        using Microsoft.Graphics.Canvas.UI;
        using Microsoft.Graphics.Canvas.UI.Xaml;
        .......
        private CanvasBitmap backgroundImage;
        private CanvasImageBrush backgroundBrush;
        private void BackgroundCanvas_CreateResources(CanvasControl sender, CanvasCreateResourcesEventArgs args)
        {
            args.TrackAsyncAction(Task.Run(async () =>
            {
                string uri = "ms-appx:///Assets/Images/GroupPattern.png";
                backgroundImage = await CanvasBitmap.LoadAsync(sender, new Uri(uri));
                backgroundBrush = new CanvasImageBrush(sender, backgroundImage);
                // Set the brush's edge behaviour to wrap, so the image repeats if the drawn region is too big
                backgroundBrush.ExtendX = backgroundBrush.ExtendY = CanvasEdgeBehavior.Wrap;
                backgroundBrush.Transform = System.Numerics.Matrix3x2.CreateScale(0.5f);
            }).AsAsyncAction());
        }
        private void BackgroundCanvas_Draw(CanvasControl sender, CanvasDrawEventArgs args)
        {
            var session = args.DrawingSession;
            session.FillRectangle(new Rect(new Point(), sender.RenderSize), backgroundBrush);
        }
