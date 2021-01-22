    if (File.Exists(imagePath))
    {
     // Create image element to set as icon on the menu element
     Image icon = new Image();
     BitmapImage bmImage = new BitmapImage();
     bmImage.BeginInit();
     bmImage.UriSource = new Uri(imagePath, UriKind.Absolute);
     bmImage.EndInit();
     icon.Source = bmImage;
     icon.MaxWidth = 25;
     item.Icon = icon;
    }
