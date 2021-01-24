    Try like this
    private void button2_Click(object sender, EventArgs e)
    {
       if(comboSelectServer.SelectedItem.ToString()== "SERV1")
        {
            MessageBox.Show("SERV1");
        }
       else if(comboSelectServer.SelectedItem.ToString()== "SERV2")
        {
            MessageBox.Show("SERV2");
        }
       else if(comboSelectServer.SelectedItem.ToString()== "SERV3")
        {
            MessageBox.Show("SERV3");
        }
    }
