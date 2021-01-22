     {
            Control[] ctls = this.Controls.Find("Button2", true);
            if (ctls.Length > 0)
            {
                Button btn = ctls[0] as Button;
                if (btn != null)
                    btn.PerformClick();
            }
            else
                MessageBox.Show("Not Found");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Button2 Clicked");
        }
