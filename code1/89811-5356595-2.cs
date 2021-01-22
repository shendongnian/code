    public override void OnApplyTemplate()
    {
      base.OnApplyTemplate();
    
      var element = GetTemplateChild("PART_EditableTextBox");
      if (element != null)
      {
        var textBox = (TextBox)element;
        textBox.SelectionChanged += OnDropSelectionChanged;
      }
    }
    
    private void OnDropSelectionChanged(object sender, RoutedEventArgs e)
    {
        // Your code
    }
