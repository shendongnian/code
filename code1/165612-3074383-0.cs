    static public void AssignLabel(this TextBox thisText, Label companionLabel) {
        thisText.Tag = companionLabel;
    }
    static public void FocusText(this TextBox thisText) {
        if (! ReferenceEquals(null, thisText.Tag))
            (Label)thisText.Tag).Visible = false;
        thisText.Focus();
    }
    void LeaveMe(this TextBox thisText) {
        if (String.IsNullOrEmpty(thisText.Text))
            ((Label)thisText.Tag).Visible = true;
    }
    //etc.
