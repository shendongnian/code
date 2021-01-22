    void tmp_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            if(txt!=null)
            {
                values.Add(txt,txt.Text);
            }
        }
