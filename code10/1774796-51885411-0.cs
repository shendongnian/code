    string textInput = "عمر"
    StringBuilder stringBuilder = new StringBuilder();
    foreach (char character in textInput)
    {
        stringBuilder.Append(Convert.ToString(character, 16).PadLeft(4,'0'));
    }
    string hex = stringBuilder.ToString();
