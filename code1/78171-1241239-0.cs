    if (File.Exists(openfile.FileName))
    {
     // Create image element to set as icon on the menu element
     BitmapImage bmImage = new BitmapImage();
     bmImage.BeginInit();
     bmImage.UriSource = new Uri(openfile.FileName, UriKind.Absolute);
     bmImage.EndInit();
     // imagebox.Source = bmImage;
    }
 
