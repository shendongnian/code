        private void tabPage1_Enter(object sender, EventArgs e)
        {
            TabPage page = (TabPage)sender;
            switch (page.TabIndex)
            {
                case 0:
                    textBox1.Text = "Page 1";
                    if (!textBox1.Focus())
                        textBox1.Focus();
                    break;
                case 1:
                    textBox2.Text = "Page 2";
                    if (!textBox2.Focus())
                        textBox2.Focus();
                    break;
                default:
                    throw new InvalidOperationException();
            }
        }
