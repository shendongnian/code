        FlowLayoutPanel panel = new FlowLayoutPanel();
        Form form = new Form();
        panel.Dock = DockStyle.Fill;
        form.Controls.Add(panel);
        for (int i = 0; i < 100; i++)
        {
            panel.Controls.Add(new TextBox());
        }
        Application.Run(form);
