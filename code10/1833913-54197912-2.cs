    public bool dtgmb = false;
    
    private void button1_Click(object sender, EventArgs e)
    {
        //Forms saved in class called FormsCollection
        FormsCollection.Form1.Hide();
        FormsCollection.Form2.Show();
    }
    
    private void button2_Click(object sender, EventArgs e)
    {
        FormsCollection.Form1.Hide();
        dtgmb = true;
        FormsCollection.Form2.Show();
    }
