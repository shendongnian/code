    private void TabItemControl_MouseEnter(object sender, MouseEventArgs e)
    {
        if (this.TabItemControl.IsSelected == false)
        {
            this.TabItemControl.Opacity = 100;
        }
    }
    private void TabItemControl_MouseLeave(object sender, MouseEventArgs e)
    {
        if (this.TabItemControl.IsSelected == false)
        {
            this.TabItemControl.Opacity = 0;
        }
    }
    private void TabAllControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (this.TabItemControl.IsSelected == false)
        {
            this.TabItemControl.Opacity = 0;
        }
    }
