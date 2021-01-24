    private void Save_Click(object sender, RoutedEventArgs e)
    {
        SaveFileDialog dlg = new SaveFileDialog();
        dlg.DefaultExt = ".png";
        dlg.Filter = ODLG_FILTER_IMAGES;
        if (dlg.ShowDialog() == true)
        {
            string filename = dlg.FileName;
            MemoryStream ms = new MemoryStream();
            FileStream fs = new FileStream(filename, FileMode.Create);
            //define your image size here...
            const int Width = 200;
            const int Height = 200;
            RenderTargetBitmap rtb = new RenderTargetBitmap(Width, Height, 96d, 96d, PixelFormats.Default);
            Rect bounds = VisualTreeHelper.GetDescendantBounds(cnv);
            DrawingVisual dv = new DrawingVisual();
            using (DrawingContext ctx = dv.RenderOpen())
            {
                VisualBrush vb = new VisualBrush(cnv);
                ctx.DrawRectangle(vb, null, new Rect(new Point(), bounds.Size));
            }
            rtb.Render(dv); ;
            BmpBitmapEncoder encoder = new BmpBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(rtb));
            encoder.Save(fs);
            fs.Close();
        }
    }
