    void Background_Method(object sender, DoWorkEventArgs e) 
    { 
        TreeView tv = new TreeView(); 
        // Generate your TreeView here
        UIDispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => 
        { 
            someContainer.Children.Add(tv);
        }; 
    }
