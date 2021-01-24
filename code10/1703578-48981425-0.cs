        if (entryName.Text == "")
        {
            MessageBox.Show("Please enter a name for the entrant");
            return;
        }
        if (pickPartner.Text == "")
        {
            MessageBox.Show("Please pick a partner to rope with");
            return;
        }
        if (comboBox1.SelectedIndex == -1)
        {
            MessageBox.Show("Please choose a role");
            return;
        }
        if(comboBox1.SelectedIndex == 0)
        {
                headerEntries.Add(entryName.Text);                   
                using (StreamWriter writeRopers = new StreamWriter("headers.txt"))
                {
                    writeRopers.WriteLine(entryName.Text);
                }
                using (StreamWriter writeRopers = new StreamWriter("teams.txt"))
                {
                    writeRopers.WriteLine(entryName.Text + " & " + pickPartner.Text);
                }
                    Debug.WriteLine(entryName.Text + " has been added as a header");
                headerCount = headerCount + 1;
                entryName.Clear();
                comboBox1.SelectedIndex = -1;
        }
