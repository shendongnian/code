    IList<string> changes = new List<string>();
    private void richtextbox_TextChanged(object sender, TextChangedEventArgs e)
    {
        //Change Detected
        var componentName = sender.GetType().Name;
        if (!changes.Contains(componentName))
            changes.Add(componentName);
    
    }
