    private void Button_Click(object sender, RoutedEventArgs e)
    {
        // Scale dimensions from 96 dpi to 600 dpi.
        double scale = 600 / 96;
        RenderTargetBitmap bmp =
            new RenderTargetBitmap
            (
                (int)(scale * (viewport3D.ActualWidth + 1)),
                (int)(scale * (viewport3D.ActualHeight + 1)),
                scale * 96,
                scale * 96,
                PixelFormats.Default
            );
        bmp.Render(viewport3D);
        rtbImage.Source = bmp;
        viewport3D.Visibility = Visibility.Collapsed;
        rtbImage.Visibility = Visibility.Visible;
    }
