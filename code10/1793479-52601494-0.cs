    void france_Click(Object sender, EventArgs e)
    {
        string capitalText = capitalTextBox.Text;
        // Set the font size
        if (largeRadioButton.Checked) // Large font size
        {
            displayLabel.FontSize = 24;
        }
        else if (smallRadioButton.Checked) // Small font size
        {
            displayLabel.FontSize = 16;
        }
        // Set the font style and font weight
        if (styleComboBox.SelectedText == "Bold") // Bold font
        {
            displayLabel.FontWeight = FontWeights.Bold;
            displayLabel.FontStyle = FontStyles.Normal; // Use non-italic and bold
        }
        else if(styleComboBox.SelectedText == "Italic") // Italic font
        {
            displayLabel.FontWeight = FontWeights.Normal;
            displayLabel.FontStyle = FontStyles.Italic; // Use italic without bold
        }
        displayLabel.Content = String.Format("The capital of France is {0}", capitalText);
    }
