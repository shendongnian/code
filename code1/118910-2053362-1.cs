    private void RequeryCommand_Executed(object sender, ExecutedRoutedEventArgs e)    
    {    
        IInputElement parent = (IInputElement)LogicalTreeHelper.GetParent((DependencyObject)e.Source);
          // Changed "sender" to "e.Source" in the line above
        MyCustControl SCurrent = new MyCustControl();    
        SCurrent = (MuCustControl)parent;    
        string str = SCurrent.Name.ToString();// Error gone
        MessageBox.Show(str);    
    }
