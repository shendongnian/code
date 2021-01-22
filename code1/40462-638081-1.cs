        TableLayoutPanel panel = new TableLayoutPanel();
        Form form = new Form();
        panel.Dock = DockStyle.Fill;
        panel.ColumnCount = 2;
        form.Controls.Add(panel);
        for (int i = 0; i < 100; i++)
        {
            panel.Controls.Add(new Label { Text = "label " + i });
            panel.Controls.Add(new TextBox { Text = "text " + i });
        }
