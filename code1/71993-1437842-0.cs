    private void BeforeFocusLost(object sender, KeyboardFocusChangedEventArgs e)
    {
      if (sender is TextBox) {
        var tb = (TextBox)sender;
        
        var bnd = BindingOperations.GetBindingExpression(tb, TextBox.TextProperty);
        
        if (bnd != null) {
          Console.WriteLine(String.Format("Preview Lost Focus: TextBox value {0} / Data value {1} NewFocus will be {2}", tb.Text, bnd.DataItem, e.NewFocus));
          bnd.UpdateSource();
        }
        Console.WriteLine(String.Format("Preview Lost Focus Update forced: TextBox value {0} / Data value {1} NewFocus will be {2}", tb.Text, bnd.DataItem, e.NewFocus));
      }
    }
