        void AddCustomer(string name)
        {
            TextBlock tb = new TextBlock();
            tb.Text = name;
            ToolTip tt = new ToolTip();
            tt.Content = "This is some info on " + name + ".";
            ToolTipService.SetToolTip(tb, tt);
            MainStackPanel.Children.Add(tb);
        }
