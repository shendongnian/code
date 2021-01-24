        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.Images.Add(errorProvider1.Icon);
            tabControl1.ImageList = imageList1;
            textBox1.Validating += textBox_Validating;
            textBox2.Validating += textBox_Validating;
        }
        private void textBox_Validating(object sender, CancelEventArgs e)
        {
            var textBox = (TextBox)sender;
            if (string.IsNullOrEmpty(textBox.Text))
            {
                this.errorProvider1.SetError(textBox, "Value is required.");
                e.Cancel = true;
            }
            else
                this.errorProvider1.SetError(textBox, null);
            var tabPage = textBox.Parent as TabPage;
            if (tabPage != null)
                ValidateTabPage(tabPage);
        }
        void ValidateTabPage(TabPage tabPage)
        {
            var tabIsValid = tabPage.Controls.Cast<Control>()
                .All(x => string.IsNullOrEmpty(errorProvider1.GetError(x)));
            if (tabIsValid)
                tabPage.ImageIndex = -1;
            else
                tabPage.ImageIndex = 0;
        }
