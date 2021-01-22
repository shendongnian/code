        // Create Data Template
        DataTemplate itemsTemplate = new DataTemplate();
        itemsTemplate.DataType = typeof (Asset);
         // Set up stack panel
         FrameworkElementFactory sp = new FrameworkElementFactory(typeof (StackPanel));
         sp.Name = "comboStackpanelFactory";
         sp.SetValue(StackPanel.OrientationProperty, Orientation.Horizontal);
         // Set up textblock
         FrameworkElementFactory assetNameText = new FrameworkElementFactory(typeof (TextBlock));
         assetNameText.SetBinding(TextBlock.TextProperty, new Binding("name"));
         sp.AppendChild(assetNameText);
         // Add Stack panel to data template
         itemsTemplate.VisualTree = sp;
         // Set the ItemsTemplate on the combo box to the new data tempalte
         comboBox.ItemTemplate = itemsTemplate;
