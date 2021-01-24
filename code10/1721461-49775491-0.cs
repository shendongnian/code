    private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 10; i < 70; i++)
            {
                Button btn = new Button();
                btn.Text = i.ToString();
                comboBox2.Items.Add(btn);
                comboBox2.DisplayMember = "Text";
            }
            System.Drawing.Text.InstalledFontCollection fonts = new System.Drawing.Text.InstalledFontCollection();
            foreach (FontFamily family in fonts.Families)
            {
                Button btn = new Button();
                btn.Text = family.Name.ToString();
                comboBox1.Items.Add(btn);
                comboBox1.DisplayMember = "Text";
            }
        }
