    public System.Windows.Forms.Label AddNewLabel()
    {
        System.Windows.Forms.Label lbl = new System.Windows.Forms.Label();
        lbl.Name = "LabelX" + this.count.ToString();
        lbl.ForeColor = Color.Black;
        lbl.Font = new Font("Sego UI", 8, FontStyle.Bold);
        lbl.Top = count * 25;
        lbl.Left = 100;
        lbl.Text = "Label 1 " + this.count.ToString();
        lbl.DoubleClick += Lbl_DoubleClick;
        lbl.BringToFront();
        panel4.Controls.Add(lbl);
        count = count + 1;
        return lbl;
    }
    private void Lbl_DoubleClick(object sender, EventArgs e)
    {
        ((Label)sender).Text = "Double Click";
    }
