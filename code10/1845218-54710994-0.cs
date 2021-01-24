        private void btnWeiter_Click(object sender, EventArgs e)
        {
            using (Form2 frm = new Form2())
            {
                List<object> list = new List<object>();
                // Pass the list to the Form2 property
                frm.listFromForm1 = list;
                // Open Form2
                frm.Show();
            }
        }
    
