    private void AddNewPr_Click(object sender, EventArgs e)
        {
            TabPage tab = new TabPage();
            _list = new ListBox();
            _list2 = new ListBox();
            PictureBox picBox = new PictureBox();
            picBox.Click = picBox_Click;
            //More stuff here
            //Add the controls        
            tabControl1.Controls.Add(tab);
            tab.Controls.Add(list);
            tab.Controls.Add(list2);
            tab.Controls.Add(pictureBox);
        }
