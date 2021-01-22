        Form2 frm;
        private void Form1_Load(object sender, EventArgs e)
        {
            frm = new Form2();
            frm.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(frm.txtUserName.Text); 
            //txtUserName is a TextBox with Modifiers=Public        
        }
