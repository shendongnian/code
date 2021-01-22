    //create the data template
    DataTemplate cardLayout = new DataTemplate();
    cardLayout.DataType = typeof(CreditCardPayment);
    
    //set up the stack panel
    FrameworkElementFactory spFactory = new FrameworkElementFactory(typeof(StackPanel));
    spFactory.Name = "myComboFactory";
    spFactory.SetValue(StackPanel.OrientationProperty, Orientation.Horizontal);
    
    //set up the card holder textblock
    FrameworkElementFactory cardHolder = new FrameworkElementFactory(typeof(TextBlock));
    cardHolder.SetBinding(TextBlock.TextProperty, new Binding("BillToName"));
    cardHolder.SetValue(TextBlock.ToolTipProperty, "Card Holder Name");
    spFactory.AppendChild(cardHolder);
    
    //set up the card number textblock
    FrameworkElementFactory cardNumber = new FrameworkElementFactory(typeof(TextBlock));
    cardNumber.SetBinding(TextBlock.TextProperty, new Binding("SafeNumber"));
    cardNumber.SetValue(TextBlock.ToolTipProperty, "Credit Card Number");
    spFactory.AppendChild(cardNumber);
    
    //set up the notes textblock
    FrameworkElementFactory notes = new FrameworkElementFactory(typeof(TextBlock));
    notes.SetBinding(TextBlock.TextProperty, new Binding("Notes"));
    notes.SetValue(TextBlock.ToolTipProperty, "Notes");
    spFactory.AppendChild(notes);
    
    //set the visual tree of the data template
    cardLayout.VisualTree = spFactory;
    
    //set the item template to be our shiny new data template
    drpCreditCardNumberWpf.ItemTemplate = cardLayout;
