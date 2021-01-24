    public void CreateCharacter()
    {
        newCharacter = new Character();  //  <-- here.
        newCharacter.Name = nameTextBox.Text;
        newCharacter.Level = levelPicker.Value;
        newCharacter.Race = racePicker.Text;
        newCharacter.Class = classPicker.Text;
    
        // ... etc
    }
