    private void btn_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
    {
        ChangeButtonOpacity((Button)sender, 1);
    }
    private void btn_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
    {
        ChangeButtonOpacity((Button)sender, 0.5);
    }
