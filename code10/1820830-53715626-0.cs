    this.BeginInvoke((Action)delegate ()
    {
    TextBox txtRun = new TextBox();
            txtRun.Name = "txtDynamic";
            txtRun.Location = new System.Drawing.Point(20, 18 + (20 * 2));
            txtRun.Size = new System.Drawing.Size(200, 25);
            f2.Controls.Add(txtRun);    
    
    });
