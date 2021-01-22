      void MyControl_LayoutUpdated(object sender, EventArgs e)
      {
                if (this.columnSeparator.ActualWidth!=0&&this.columnSeparator.ActualWidth != this.columnSeparator.MinWidth)
                {
                    this.IsLoaded = true;
                    SetWidth();
                }
      }
    
     private void SetWidth()
            {
                if (IsWidthSet)
                    return;
                if (!this.IsLoaded)
                    return;
                var parentPanel = this.Parent as Panel;
                if (parentPanel != null)
                {
                    var textFields = parentPanel.Children.Where(p => p is BpTextField).Cast<BpTextField>().ToList();
                    double max = this.LabelWidth;
                    foreach (var textField in textFields)
                    {
                        max = Math.Max(max, textField.LabelWidth);
                        if (!textField.IsLoaded)
                            return;
                    }
    
                    foreach (var textField in textFields)
                    {
                        textField.LabelWidth = max;
                    }
    
                    this.LabelWidth = max;
                }
            }
            public bool IsLoaded { get; set; }
            public bool IsWidthSet { get; set; }
