     private void deatilsShowHide(object sender, RoutedEventArgs e) 
     { 
         if(rightColumn.Width == new GridLength(10))
            {
                rightColumn.Width = new GridLength(300);
            }
            else
            {
                rightColumn.Width = new GridLength(10);
            }
    }
