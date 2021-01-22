    static void OnWatermarkChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
        var textbox = (TextBox)d;
        textbox.Loaded += UpdateWatermark;
        textbox.TextChanged += UpdateWatermark;
    }
    static void UpdateWatermark(object sender, RoutedEventArgs e) {
        var textbox = (TextBox)sender;
        var layer = AdornerLayer.GetAdornerLayer(textbox);
        if (layer != null) {
            if (textbox.Text == string.Empty) {
                layer.Add(new WatermarkAdorner(textbox, GetWatermark(textbox)));
            } else {
                var adorners = layer.GetAdorners(textbox);
                if (adorners == null) {
                    return;
                }
                foreach (var adorner in adorners) {
                    if (adorner is WatermarkAdorner) {
                        adorner.Visibility = Visibility.Hidden;
                        layer.Remove(adorner);
                    }
                }
            }
        }
    }
