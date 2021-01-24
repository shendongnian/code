    private BitmapImage source = new BitmapImage(new Uri("pack://application:,,,/images/pic.png"));
    private double rotation = 0;
    private void Rotate_Click(object sender, RoutedEventArgs e)
    {
        rotation += 90;
        image_box.Source = new TransformedBitmap(source, new RotateTransform(rotation));
    }
