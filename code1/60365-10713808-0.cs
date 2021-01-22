        private void SettingGroupBoxColor(bool bSelected)
        {
            if (!bSelected)
                groupBox1.ForeColor = Color.Red;
            else
                groupBox1.ForeColor = Color.Green;
            foreach (Control c in this.groupBox1.Controls)
            {
                c.ForeColor = Color.Black;
            }
        }
