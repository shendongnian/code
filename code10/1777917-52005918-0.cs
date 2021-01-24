    foreach(Control ctrl in panel1.Controls)
            {
                if(ctrl is TextBox)
                {
                    ctrl.Click += new EventHandler(OpenSecondForm_Click); 
                }
            }
    private void OpenSecondForm_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
        }
