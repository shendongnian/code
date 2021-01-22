    private void button1_Click(object sender, EventArgs e)
    {   
        string get = label1.Text.Substring(7); //label1.text=ATHCUS-100
        MessageBox.Show(get);
        string ou="ATHCUS-"+(Convert.ToInt32(get)+1).ToString();
        label1.Text = ou.ToString();
           
    }
