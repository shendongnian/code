    private void fndBtn_Click(object sender, EventArgs e)
    {
        BindingSource src = new BindingSource();
        src.DataSource = dataGridView1.DataSource;
        int findedRow = 0;
        if (textBox1.Text!="")
              findedRow = src.Find("p_Name", textBox1.Text); 
        if (findedRow!=-1)
               src.Position = findedRow ;
    }
