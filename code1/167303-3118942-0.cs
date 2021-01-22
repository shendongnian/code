        void btnContacts_MouseClick(object sender, MouseEventArgs e)
        {            
            using (frmContactList f = new frmContactList())
            {
                if (f.ShowDialog(fPrompt) == DialogResult.Cancel)
                {
                    var contact = f.ContactItem;
                    TextBox tbx = ((Button)sender).Parent.Controls[0] as TextBox;
                    tbx.Text = contact.Email1Address;
                }
            }
        }
