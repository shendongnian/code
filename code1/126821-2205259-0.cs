        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        theCanvas.Width = 2740;
        theCanvas.Height = 2280; 
        Button button = new Button();
        button.Content = "Push Me.";
        button.Height = 50;
        button.Width = 200;
        Canvas.SetTop(button, 200);
        Canvas.SetLeft(button, 300);
        theCanvas.Children.Add(button);
        mainGri.Children.Add(theCanvas);
        }
        private void mainGri_MouseDown(object sender, MouseButtonEventArgs e)
        {
  
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            String path = @"c:\\a.jpg";
            using (System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.Create))
            {
                int inWidth = 300;
                int inHeight = 400;
                RenderTargetBitmap renderBitmap = new RenderTargetBitmap((int)inWidth,
                                                                  (int)inHeight, 1 / 300, 1 / 300, PixelFormats.Pbgra32);
                DrawingVisual visual = new DrawingVisual();
                using (DrawingContext context = visual.RenderOpen())
                {
                    VisualBrush brush = new VisualBrush(theCanvas);
                    context.DrawRectangle(brush,
                                          null,
                                          new Rect(new Point(), new Size(inWidth, inHeight)));
                }
                renderBitmap.Render(visual);
                BitmapEncoder encoder = new TiffBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(renderBitmap));
                encoder.Save(fs);
                fs.Close();
            }
        }
    }
}
