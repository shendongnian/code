    void Add_Controls(DependencyObject start)
    {
         if (start == null) return;
         var items = new Queue<DependencyObject>();
         items.Enqueue(start);
         while (items.Count > 0)
         {
             var item = items.Dequeue();
             var name = (string)item.GetValue(FrameworkElement.NameProperty);
             if (!String.IsNullOrEmpty(name))
                 ControlsByName.Add(name, item);
             foreach (var child in LogicalTreeHelper.GetChildren(item))
                 items.Enqueue(child);
         }
    }
