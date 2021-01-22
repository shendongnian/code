    private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
    {
        switch (tabControl1.SelectedIndex)
        {
            case 0:
                AcceptButton = button1;
                break;
            case 1:
                AcceptButton = button2;
                break;
        }
    }
