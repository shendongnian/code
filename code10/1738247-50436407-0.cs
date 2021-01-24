    private void remove_Click(object sender, EventArgs e)
            {
                Button button = sender as Button;
                String s = button.Name;
                s = s.Substring(6);
                int index;
    
                index = Convert.ToInt32(s);
                Note note = MyNotes.noteList.ElementAt(index);
    
                this.Controls.Remove(note.GetBox());
                this.Controls.Remove(note.GetSaveButton());
                this.Controls.Remove(note.GetRemoveButton());
    
                MyNotes.noteList.Remove(note);
    
                int x = MyNotes.noteList.Count;
                MessageBox.Show(x.ToString());
       
            }
