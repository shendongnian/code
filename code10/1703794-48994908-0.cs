    private void btnAdd_Click(object sender, EventArgs e)
    {
        for (int count = 0;count < 4; count++)
        {
            Label label = new Label();
            label.Location = new Point(10, (25 * count) + 2);
            label.Size = new Size(40, 20);
            label.ForeColor = System.Drawing.Color.White;
            label.Name = "label_" + (count + 1);
            label.Text = "Field " + (count + 1);
            panel3.Controls.Add(label);
    
            TextBox textbox = new TextBox();
            count = panel1.Controls.OfType<TextBox>().ToList().Count;
            textbox.Location = new Point(60, 25 * count);
            textbox.Size = new Size(301, 20);
            textbox.Name = "textbox_" + (count + 1);
            textbox.TextChanged += new System.EventHandler(this.TextBox_Changed);
            panel3.Controls.Add(textbox);
        }        
    }
