        private void srvList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (srvList.SelectedIndex == -1)
            {
                dltButton.Visible = false;
            }
            else
            {
                dltButton.Visible = true;
            }
            string path = @"C:\Test\" + srvList.SelectedItem + ".txt";
            StreamReader sr = new StreamReader(path);
            //Text being displayed to the left of the server listbox
            mapLabel1.Text = sr.ReadLine();  // mapSelect;
            difLabel1.Text = sr.ReadLine();  // difSelect;
        }
