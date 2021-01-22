        public void Button1_Click(object sender, EventArgs e)
        {
            foreach (Control c in fv1.Controls)
            {
                if (c is ListBox)
                {
                    ListBox lbx = c as ListBox;
                    ++lbx.SelectedIndex;
                }
            }
        }
