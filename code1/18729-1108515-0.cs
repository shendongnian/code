    // Clear the existing item(s) (this will actually remove the "English" element defined in XAML)
    LanguageMenu.Items.Clear(); 
    
    // Dynamically get flag images from a specified folder to use for definingthe menu items 
    string[] files = Directory.GetFiles(Settings.LanguagePath, "*.png");
    foreach (string imagePath in files)
    {
      // Create the new menu item
      MenuItem item = new MenuItem();
      
      // Set the text of the menu item to the name of the file (removing the path and extention)
      item.Header = imagePath.Replace(Settings.LanguagePath, "").Replace(".png", "").Trim("\\".ToCharArray());
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
      
      // Hook up the event handler (in this case the method File_Language_Click handles all these menu items)
      item.Click += new RoutedEventHandler(File_Language_Click); 
      
      // Add menu item as child to pre-defined menu item
      LanguageMenu.Items.Add(item); // Add menu item as child to pre-defined menu item
    }
