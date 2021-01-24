    ModuleStackpanels[i].Children.Add(ModuleCheckBoxes[i]);
    StackPanel.SetZIndex(ModuleCheckBoxes[i], 2);
    ModuleCheckBoxes[i].CheckedChanged += new EventHandler(ModuleCheckBoxClick);
    private void ModuleCheckBoxClick(object sender, RoutedEventArgs e)
    {
        int CheckBoxCounter = 0;
    
        for(int i=0;i<30;i++)
        {
            if (ModuleCheckBoxes[i].IsChecked == true) CheckBoxCounter++;
        }
    
        if(CheckBoxCounter > 1)
        {
            Button_QueryStatus.IsEnabled = false;
        }
    }
