    private BitmapImage source = new BitmapImage(new Uri("pack://application:,,,/images/pic.png"));
    private double rotation = 0;
    private TransformedBitmap transformedBitmap =
        new TransformedBitmap(source, new RotateTransform(rotation));
    ...
    image_box.Source = transformedBitmap; // call this once
    ...
    private void Rotate_Click(object sender, RoutedEventArgs e)
    {
        rotation += 90;
        transformedBitmap.Transform = new RotateTransform(rotation);
    }
