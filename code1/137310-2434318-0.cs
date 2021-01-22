    private void btn_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e) 
    { 
        (sender as Button).Opacity = (double)((sender as Button).Tag); 
    } 
    
    private void btn_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e) 
    { 
        (sender as Button).Opacity = 0.5;
    } 
