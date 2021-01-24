     public System.Windows.Forms.Label AddNewLabel()
            {
                System.Windows.Forms.Label lbl = new System.Windows.Forms.Label();
                lbl.Name = "LabelX" + this.count.ToString();
                lbl.Top = 85;
                lbl.Left = 100;
                lbl.Text = "Label"+count;
                lbl.AutoSize = true;
                panel4.Controls.Add(lbl);
                //multiple events
                lbl.MouseMove += Control_NewEvent1;
                lbl.MouseDown += Control_NewEvent2;
                count = count + +;
                lbl.BringToFront();
                return lbl;
            }
    
    //Events
    private void Control_NewEvent1(object sender, EventArgs e)
    {
             ((Label)sender).ForeColor = Color.White;
    }
    private void Control_NewEvent2(object sender, EventArgs e)
    {
              ((Label)sender).BackColor = Color.Black;
    }
