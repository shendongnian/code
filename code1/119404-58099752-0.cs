    Regex Rx = null;
                Rx = new System.Text.RegularExpressions.Regex("^(?=.*?[A-Za-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{7,}$");
                
            
                if (Rx.IsMatch(textBox3.Text))
                {
                    textBox3.BackColor = Color.Green;
                    textBox3.ForeColor = Color.White;
                    MessageBox.Show("Password is (correct) format ");
                }
                else
                {
                    textBox3.BackColor = Color.DarkRed;
                    textBox3.ForeColor = Color.White;
                    MessageBox.Show("Contact is (in-correct) format");
    
                }  
