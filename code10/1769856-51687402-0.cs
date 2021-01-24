    private void button1_Click(object sender, EventArgs e)
    {
       user u = udash.Testing(u);
       if (u == null)
       {
          MessageBox.Show("Empty data");
        }else
         MessageBox.Show(u.firstname);
    
     }
