    private async Task PrintMe(object sender, System.Windows.RoutedEventArgs e)
    {
        PrintDialog print = new PrintDialog();
        int savedSelectedIndex = this.tabControl.SelectedIndex;
        if (print.ShowDialog())  // == true is redundant; don't do that.
        {
            for (int i = 0; i < this.tabControl.Items.Count; i++)
            {
                this.tabControl.SelectedIndex = i;
                // Allow the UI to update by yielding to the message loop
                // or whatever it is that controls the UI thread.
                await Task.Delay(100);
                print.PrintVisual(this.MainGrid, "Report");
            }
        }
        // And of course, "be kind, rewind"
        this.tabControl.SelectedIndex = savedSelectedIndex;
    }
