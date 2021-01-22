      private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                main_normal frm2 = new main_normal();
                this.Hide(); //Hides Form1
                frm2.ShowDialog(); //Displays main_normal
                this.ShowDialog(); //After the main_normal is closed, again displays Form1
            }
            catch (Exception ex)
            {
                //this.Show();
                MessageBox.Show(ex.Message, "wub wub Noe feilet men eg vet isje ka", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
