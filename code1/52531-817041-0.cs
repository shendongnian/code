      private void button1_Click(object sender, EventArgs e)
            {
                Form2 frm = new Form2();
                frm.Show();
                frm.FormIsClosing += frm_FormIsClosing;
                   
            }
    
            void frm_FormIsClosing(object sender, DialogResult rsl)
            {
                if (rsl == System.Windows.Forms.DialogResult.Yes)
                    MessageBox.Show("We got it");
            }
