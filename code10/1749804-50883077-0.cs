    string statusP = ""; // will be seen in the whole class.
    public void potwierdzWybor_Click(object sender, EventArgs e)
        {
           
            if (platnoscT.Checked == true)
            {
                statusP = "O";
                Label1.Text = statusP;
            }
            else if (platnoscP.Checked == true)
            {
                statusP = "P";
                Label1.Text = statusP;
            }
            else
            {
                Label1.Text = "Nothing choose";
            }
    
    }
