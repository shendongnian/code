    void france_Click(Object sender, EventArgs e)
    {
        int fontSize = 24;
        FontStyle fontStyle = FontStyle.Regular | FontStyle.Bold;
    
        // Set the font size
        if (largeRadioButton.Checked) // Large font size
        {
            fontSize = 24;
        }
        else if (smallRadioButton.Checked) // Small font size
        {
            fontSize = 16;
        }
    
        // Set the font style and font weight
        if (styleComboBox.SelectedText == "Bold") // Bold font
        {
            fontStyle = FontStyle.Bold;
        }
        else if (styleComboBox.SelectedText == "Italic") // Italic font
        {
            fontStyle = FontStyle.Italic;
        }
        // Apply the font style.
        displayLabel.Font = new Font("Arial", fontSize, fontStyle);
        // Set the text.
        displayLabel.Text = String.Format("The capital of France is {0}", capitalTextBox.Text);
    }
