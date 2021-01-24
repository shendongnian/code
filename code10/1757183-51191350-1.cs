     private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] splitString;
            
            string stringToSplit = listBox1.Items[listBox1.SelectedIndex].ToString();
            
    
            splitString = listBox1.Items[listBox1.SelectedIndex].ToString().Split(',');
    
            textBox2.Text = splitString[0];
            if (splitString.Length>1) {
                textBox3.Text = splitString[1];
            }
            else
            {
                textBox3.Text = "";
            }
    
        }
