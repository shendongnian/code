       protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
       {
        if (! myUserControl.AllowClose)
        {
            MessageBox.Show("Even though most Windows allow Alt-F4 to close, I'm not letting you!");
            e.Cancel = true;
        }
        else
        {
            //Content = null; // Remove child from parent - for reuse
            this.RemoveLogicalChild(Content); //this works faster
            base.OnClosing(e);
            { GC.Collect(); };
        }
    }
