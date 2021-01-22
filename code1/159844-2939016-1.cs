    var names = new[] { "C1", "C2", "C3" };
    // search for specified names only within textboxes
    var controls = this.Controls
        .OfType<TextBox>()
        .Where(c => names.Contains(c.Name));
    
    // put the search result into a Dictionary<TextBox, string>
    var dic = controls.ToDictionary(k => k, v => v.Text); 
