    private void lblMyLabel_Click(object sender, EventArgs e)
    {
                //Add Code here.
    }
    
            public System.Windows.Forms.Label AddNewLabel()
            {
                int count = 1;
                System.Windows.Forms.Label lbl = new System.Windows.Forms.Label();
                lbl.Name = "LabelX" + count;
                lbl.ForeColor = Color.Black;
                lbl.Font = new Font("Sego UI", 8, FontStyle.Bold);
                lbl.Top = count * 25;
                lbl.Left = 100;
                lbl.Text = "Label 1 " + count;
                lbl.BringToFront();
                //Wire relevant event handler here
                lbl.Click += lblMyLabel_Click;
                panel4.Controls.Add(lbl);
                count ++;
    
                return lbl;
            }
