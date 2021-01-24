        private void crtButton_Click(object sender, EventArgs e)
        {
            //Add srvName to srvList
            srvName = namBox1.Text;
            srvList.Items.Add(srvName);
            //Selections
            mapSelect = mapBox1.Text;
            difSelect = difBox1.Text;
            //Write to config file
            string path = @"C:\Test\" + srvName + ".txt";
            StreamWriter sw = new StreamWriter(path);
            sw.WriteLine(mapSelect);
            sw.WriteLine(difSelect);
            sw.Flush();
            sw.Close();
            //Clear newPanel form
            namBox1.Text = String.Empty;
            mapBox1.SelectedIndex = -1;
            difBox1.SelectedIndex = -1;
            //Return to srvList
            //newPanel.Visible = false;
        }
