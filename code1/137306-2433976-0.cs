    private void FadeBtn_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
    {
        Button btn = (Button)sender;
        btn.Opacity = 1;
    }
    
    private void FadeBtn_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
    {
        Button btn = (Button)sender;
        btn.Opacity = 0.5;
    }
