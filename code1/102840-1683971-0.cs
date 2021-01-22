    private void image1_MouseEnter(object sender, MouseEventArgs e)
    {
        Image img = ((Image)sender);
        img.Height = img.ActualHeight * 1.1;
        
    }
    private void image1_MouseLeave(object sender, MouseEventArgs e)
    {
        Image img = ((Image)sender);
        img.Height /= 1.1;
    }
