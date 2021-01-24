    /// <summary>
    /// Convert text from the input textBox to actual chars correpsonding to the chosen encoding.
    /// This can be used for converting back to bytes; or for clipboard copy.
    /// </summary>
    /// <param name="text">Text from the TextBox.</param>
    /// <returns>The normalized string.</returns>
    private Char[] FlattenText(String text)
    {
        Char[] preparedOutput = text.Replace(Environment.NewLine, "\r").ToCharArray();
        for (Int32 i = 0; i < preparedOutput.Length; i++)
        {
            Int32 index = ASCII_CONTROL.IndexOf(preparedOutput[i]);
            if (index != -1)
                preparedOutput[i] = this._validCharactersLowRange[index];
        }
        return preparedOutput;
    }
