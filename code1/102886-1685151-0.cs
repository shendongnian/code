    Button MondayXXXButton = new Button();      // I assume your buttons are created somewhere
    MondayXXXButton.Name = "MondayXXXButton";
    MondayXXXButton.Text = "Hello world";
    
    OrderedDictionary buttons = new OrderedDictionary();
    buttons.Add(MondayXXXButton.Name, MondayXXXButton);
    // etc: for each button
