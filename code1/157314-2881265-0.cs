    // Create the Button.
    Button origianlButton = new Button();
    origianlButton.Height = 50;
    origianlButton.Width = 100;
    origianlButton.Background = Brushes.AliceBlue;
    origianlButton.Content = "Click Me";
    
    // Save the Button to a string.
    string savedButton = XamlWriter.Save(origianlButton);
    
    // Load the button
    StringReader stringReader = new StringReader(savedButton);
    XmlReader xmlReader = XmlReader.Create(stringReader);
    Button readerLoadButton = (Button)XamlReader.Load(xmlReader);
