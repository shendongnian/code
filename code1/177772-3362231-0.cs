    // Create the control and give it an ID
    LinkButton lbtnCharacters = new LinkButton();
    lbtnCharacters.ID = Char.ConvertFromUtf32(i);
    
    // Add the control to it's parent ControlCollection
    alphabets.Controls.Add(lbtnCharacters);
    
    // Assign the properties
    lbtnCharacters.Text = "<u>" + Char.ConvertFromUtf32(i) + "</u>";
    ... // Etc
