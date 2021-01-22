    // NOTE: first parameter "this TextBox thisText"- these are all extension methods.
    
    static public void AssignLabel(this TextBox thisText, Label companionLabel) {
        thisText.Tag = companionLabel;
        // HOOK UP EVENT AT THIS POINT, WHEN LABEL IS ASSIGNED (.NET 3.x)
        thisText.Leave += (Object sender, EventArgs e) => {
            LeaveMe(thisText); // Invoke method below.
        };
    }
    static public void FocusText(this TextBox thisText) {
        if (! ReferenceEquals(null, thisText.Tag))
            (Label)thisText.Tag).Visible = false;
        thisText.Focus();
    }
    static public void LeaveMe(this TextBox thisText) {
        if (String.IsNullOrEmpty(thisText.Text))
            ((Label)thisText.Tag).Visible = true;
    }
    //etc.
