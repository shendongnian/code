        private void button1_Click(object sender, EventArgs e)
        
          {
            string s = textBox1.Text;           
            string DFF = textBox3.Text;          
            
            //To check whether field is empty
            if (String.IsNullOrEmpty(s))
            { 
              MessageBox.Show("Please enter correct date");
              textBox2.Text = "Enter correct date";
            }           
            else
            {
                DateTime dt = DateTime.ParseExact(s, DFF, null);
                textBox2.Text = dt.ToShortDateString();
             }
            
        }
