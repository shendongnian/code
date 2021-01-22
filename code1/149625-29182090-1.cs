    private void button1_Click_2(object sender, EventArgs e)
      {
           foreach (ArrayList li in list)
                {
    
    
                  
                    pic_trans.Visible = true;
                    pic_trans.Location = new Point(Convert.ToInt32(li[0]), Convert.ToInt32(li[1]));
                    pic_trans.Show();
                 }
      }
