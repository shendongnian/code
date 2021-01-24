    // Class Note
    private void removeSettings()
    {
        remove = new Button();
        remove.Text = "X";
        remove.TextAlign = ContentAlignment.MiddleCenter;
        remove.Width = 20;
        remove.Tag = this; // Store the current Note in its remove button
    }
    
    // Class Form1
    private void remove_Click(object sender, EventArgs e)
    {
    	Button btn = sender as Button;
        Note note = btn.Tag as Note;
    
        Controls.Remove(note.GetBox());
        Controls.Remove(note.GetSaveButton());
        Controls.Remove(note.GetRemoveButton());
    }
