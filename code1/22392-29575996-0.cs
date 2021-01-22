    Assembly asm = Assembly.GetExecutingAssembly();
    Stream iconStream = asm.GetManifestResourceStream(asm.GetName().Name + "." + "Desert.jpg");
    BitmapImage bitmap = new BitmapImage();
    bitmap.BeginInit();
    bitmap.StreamSource = iconStream;
    bitmap.EndInit();
    image1.Source = bitmap;
