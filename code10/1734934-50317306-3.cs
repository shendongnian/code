    private void button1_Click(object sender, EventArgs e)
    {   
       var  dr =  dataGridView1.SelectedRows[0];
       string item1 = dr.Cells[0].Value.ToString();
       string item2 = dr.Cells[1].Value.ToString();
       string item3 = dr.Cells[2].Value.ToString();
       // What was added
       TheSecondForm frm2 = new TheSecondForm(item1, item2, item3);
       frm2.Show();
    }
