     private void canvass_PreviewMouseDown(object sender, MouseButtonEventArgs e) 
        {
    if (_Move.IsChecked == true && filmgrid.Visibility == Visibility.Visible)// == true)  
                {
                    filmgrid.PreviewMouseDown += new MouseButtonEventHandler(dragme); 
                }
}
