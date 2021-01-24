        InstalledFontCollection fonts;
        private void Form1_Load(object sender, EventArgs e)
        {
            InstalledFontCollection fonts = new InstalledFontCollection();
            try
            {
                foreach (FontFamily font in fonts.Families)
                {
                    listBox1.Items.Add(font.Name);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(e.ToString());
            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Font = new Font(listBox1.SelectedItem.ToString(), textBox1.Font.Size);
        }
