    /// <summary>
    /// In order to control itemcheck changes (blinds double clicking, among other things)
    /// </summary>
    bool AuthorizeCheck { get; set; }
    private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
    {
        if(!AuthorizeCheck)
            e.NewValue = e.CurrentValue; //check state change was not through authorized actions
    }
    private void checkedListBox1_MouseDown(object sender, MouseEventArgs e)
    {
        Point loc = this.checkedListBox1.PointToClient(Cursor.Position);
        for (int i = 0; i < this.checkedListBox1.Items.Count; i++)
        {
            Rectangle rec = this.checkedListBox1.GetItemRectangle(i);
            rec.Width = 16; //checkbox itself has a default width of about 16 pixels
            if (rec.Contains(loc))
            {
                AuthorizeCheck = true;
                bool newValue = !this.checkedListBox1.GetItemChecked(i);
                this.checkedListBox1.SetItemChecked(i, newValue);//check 
                AuthorizeCheck = false;
                return;
            }
        }
    }
