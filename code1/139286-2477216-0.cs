    private void Form1_Load(object sender, EventArgs e)
    {
        Panel tabBackground = new Panel
        {
            Location = tabControl1.Location,
            Size = tabControl1.Size,
            // Your color here
            BackColor = Color.Magenta
        };
        tabBackground.Controls.Add(tabControl1);
        Controls.Add(tabBackground);
        tabControl1.Dock = DockStyle.Fill;
    }
