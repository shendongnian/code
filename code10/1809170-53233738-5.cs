    // makes sure your app isn't crashing upon backspaces.
    if(string.IsNullOrEmpty(textCost.Text))
    {
        // Personally i'd indicate the user nothing is typed in (yet).
        return;
    }
    if (!double.TryParse(txtCost.Text, out var dblCostSqFt))
    {
        // The user filled in something that can't be parse to doubles.
        MessageBox.Show("Error. You must enter valid numbers. Please correct.");
        txtExample.Select(0, txtCost.Text.Length);
        return;
    }
    // All is great; Do stuff with dblCostSqFt.
