    // Initialize the button
    Button myButton = new Button();
    // Set its properties
    myButton.Width = 160;
    myButton.Height = 72;
    myButton.Content = "Click Me";
    // Attach it to the visual tree, specifically as a child of
    // a Grid object (named 'ContentPanel') that already exists. In other words, position
    // the button in the UI.
    ContentPanel.Children.Add(myButton);
