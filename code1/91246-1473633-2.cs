       private void Details_Click(object sender, RoutedEventArgs e)
        {
          try
          {
            // the original source is what was clicked.  For example 
            // a button.
            DependencyObject dep = (DependencyObject)e.OriginalSource;
    
            // iteratively traverse the visual tree upwards looking for
            // the clicked row.
            while ((dep != null) && !(dep is DataGridRow))
            {
              dep = VisualTreeHelper.GetParent(dep);
            }
    
            // if we found the clicked row
            if (dep != null && dep is DataGridRow)
            {
              // get the row
              DataGridRow row = (DataGridRow)dep;
    
              // change the details visibility
              if (row.DetailsVisibility == Visibility.Collapsed)
              {
                row.DetailsVisibility = Visibility.Visible;
              }
              else
              {
                row.DetailsVisibility = Visibility.Collapsed;
              }
            }
          }
          catch (System.Exception)
          {
          }
        }
