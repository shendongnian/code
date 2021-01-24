    private void textBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
    {
        if (e.KeyCode == Keys.Enter && textBox1.Text != "")
        {
            Label lbl = new Label {
                Text = "      " + textBox1.Text,  /* some room for the image */
                BorderStyle = BorderStyle.Fixed3D,
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = true,
                Margin = new Padding(2),
                ImageIndex = flowLayoutPanel1.Controls.Count % 
                             imageList1.Images.Count,
                ImageList = imageList1,
                ImageAlign = ContentAlignment.MiddleLeft,
                MinimumSize = new Size(100, 20),
                BackColor = Color.LightGoldenrodYellow,
                Name = "TagLabel" + (flowLayoutPanel1.Controls.Count)
            };
            lbl.MouseClick +=lbl_MouseClick ;
            flowLayoutPanel1.Controls.Add(lbl);
            flowLayoutPanel1.Controls.SetChildIndex(lbl, 
                                      flowLayoutPanel1.Controls.Count - 2);
            textBox1.Text = "";
        }
        else
        if (e.KeyCode == Keys.Escape)
        {
            textBox1.Text = "";
        }
    }
