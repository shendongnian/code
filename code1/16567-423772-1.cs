        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Location = new System.Drawing.Point(198, 234);
            groupBox2.Location = new System.Drawing.Point(660, 234);
            groupBox1.Visible = true;
            groupBox2.Visible = false;
            
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Location = new System.Drawing.Point(660, 234);
            groupBox2.Location = new System.Drawing.Point(198, 234); 
            groupBox1.Visible = false;
            groupBox2.Visible = true;
        }
