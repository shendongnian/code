    private void textBox1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
    {
        switch (e.KeyChar)
        {
            case 'A':
                Aoff.Visible = false;
                Aon.Visible = true;
                break;
            case 'B':
                Boff.Visible = false;
                Bon.Visible = true;
                break; 
                
            ...
        }
    }
