    //Looping through the controls.
    for (int i = 0; i < this.tabControl1.TabPages.Count; i++)
    {
        Rectangle r = tabControl1.GetTabRect(i);
       //Getting the position of the "x" mark.
        Rectangle closeButton = new Rectangle(r.Right - 15, r.Top + 4, 9, 7);
        if (closeButton.Contains(e.Location))
        {
            if (MessageBox.Show("Would you like to Close this Tab?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.tabControl1.TabPages.RemoveAt(i);
                break;
            }
        }
    }
