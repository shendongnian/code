    Assembly asm = Assembly.GetExecutingAssembly();
    Stream iconStream = asm.GetManifestResourceStream("SomeImage.png");
    BitmapImage bitmap = new BitmapImage();
    bitmap.BeginInit();
    bitmap.StreamSource = iconStream;
    bitmap.EndInit();
    _icon.Source = bitmap;
