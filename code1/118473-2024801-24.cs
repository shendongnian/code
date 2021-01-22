    Control[] foundControls = null;
    // Find control with Name="tabs1".
    foundControls = FilterControls(this,
        c => c.Name != null && c.Name.Equals("tabs1"));
    // Find all controls that start with ID="panel*...
    foundControls = FilterControls(this,
        c => c.Name != null && c.Name.StartsWith("panel"));
    // Find all Tab Pages in this form.
    foundControls = FilterControls(this,
        c => c is TabPage);
    Console.Write(foundControls.Length); // is an empty array if no matches found.
