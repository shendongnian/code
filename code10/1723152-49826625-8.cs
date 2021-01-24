    // Returns all controls under the parent with the specified tag
    private List<Control> GetTaggedControls(string tag, Control parent)
    {
        var taggedControls = new List<Control>();
        foreach (Control control in parent.Controls)
        {
            if (control.Tag?.ToString() == tag)
            {                
                taggedControls.Add(control);
            }
            // Recursively call this method in case this is a container
            taggedControls.AddRange(GetTaggedControls(tag, control));
        }
        return taggedControls;
    }
    // Deletes all controls with the specified tag
    private void DeleteControlsWithTag(string tag)
    {
        foreach (Control control in GetTaggedControls(tag, this))
        {
            Controls.Remove(control);
        }
    }
