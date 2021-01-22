          if(child != null)
          {
            SomeObject parent = child.Parent;
            // Find the currently focused element in the TreeView's focus scope
            DependencyObject focused =
              FocusManager.GetFocusedElement(
                FocusManager.GetFocusScope(tv)) as DependencyObject;
            // Scan up the VisualTree to find the TreeViewItem for the parent
            var parentContainer = (
              from element in GetVisualAncestorsOfType<FrameworkElement>(focused)
              where (element is TreeViewItem && element.DataContext == parent)
                    || element is TreeView
              select element
              ).FirstOrDefault();
            parent.Children.Remove(child);
            if(parent.Children.Count > 0)
            {
              // Before selecting child, first focus parent's container
              if(parentContainer!=null) parentContainer.Focus();
              parent.Children[0].IsSelected = true;
            }
          }
