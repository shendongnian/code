    string text = {text to replace characters in};
    Dictionary<char, char> replacements = new Dictionary<char, char>();
    // add your characters to the replacements dictionary, 
    // key: char to replace
    // value: replacement char
    replacements.Add('ç', 'c');
    ...
    System.Text.StringBuilder replaced = new System.Text.StringBuilder();
    for (int i = 0; i < text.Length; i++)
    {
        char character = text[i];
        if (replacements.ContainsKey(character))
        {
            replaced.Append(replacements[character]);
        }
        else
        {
            replaced.Append(character);
        }
    }
    // 'replaced' is now your converted text
