        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            this.SuspendLayout();
            int seldCount = checkBox1.Checked ? 1 : 0;
            seldCount += checkBox2.Checked ? 1 : 0;
            seldCount += checkBox3.Checked ? 1 : 0;
            seldCount += checkBox4.Checked ? 1 : 0;
            float pcnt = 0;
            if (seldCount == 1)
                pcnt = 1;
            if (seldCount == 2)
                pcnt = 0.5f;
            if (seldCount == 3)
                pcnt = 0.33f;
            if (seldCount == 4)
                pcnt = 0.25f;
            int newHeight = (int)(tableLayoutPanel1.Height * pcnt);
            if (checkBox1.Checked)
            {
                tableLayoutPanel1.RowStyles[0].SizeType = SizeType.Percent;
                tableLayoutPanel1.RowStyles[0].Height = newHeight;
            }
            else
            {
                tableLayoutPanel1.RowStyles[0].SizeType = SizeType.Absolute;
                tableLayoutPanel1.RowStyles[0].Height = 0;
            }
            if (checkBox2.Checked)
            {
                tableLayoutPanel1.RowStyles[1].SizeType = SizeType.Percent;
                tableLayoutPanel1.RowStyles[1].Height = newHeight;
            }
            else
            {
                tableLayoutPanel1.RowStyles[1].SizeType = SizeType.Absolute;
                tableLayoutPanel1.RowStyles[1].Height = 0;
            }
            if (checkBox3.Checked)
            {
                tableLayoutPanel1.RowStyles[2].SizeType = SizeType.Percent;
                tableLayoutPanel1.RowStyles[2].Height = newHeight;
            }
            else
            {
                tableLayoutPanel1.RowStyles[2].SizeType = SizeType.Absolute;
                tableLayoutPanel1.RowStyles[2].Height = 0;
            }
            if (checkBox4.Checked)
            {
                tableLayoutPanel1.RowStyles[3].SizeType = SizeType.Percent;
                tableLayoutPanel1.RowStyles[3].Height = newHeight;
            }
            else
            {
                tableLayoutPanel1.RowStyles[3].SizeType = SizeType.Absolute;
                tableLayoutPanel1.RowStyles[3].Height = 0;
            }
            this.ResumeLayout();
        }
