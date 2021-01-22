    void Recurse_Controls(DependencyObject start)
    {
         if (start == null) return;
         var name = (string)start.GetValue(FrameworkElement.NameProperty);
         if (!String.IsNullOrEmpty(name))
             ControlsByName.Add(name, start);
         foreach (var child in LogicalTreeHelper.GetChildren(start))
             Recurse_Controls(child);
    }
