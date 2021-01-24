        private void button1_Click(object sender, EventArgs e)
        {
       
            x++;
            if (x == 1)
            {
                label1.Text = 1.ToString();
                if (label1.Text == 1.ToString())
                    panel2.Visible = true;
                return;
            }
            if (x == 2)
            {
                label2.Text = 1.ToString();
                if (label2.Text == 1.ToString())
                    panel4.Visible = true;
                return;
              
            }
            if (x == 3)
            {
                label3.Text = 1.ToString();
                if (label3.Text == 1.ToString())
                    panel6.Visible = true;
                return;
            }
        
         
     
        }
    }
    }
