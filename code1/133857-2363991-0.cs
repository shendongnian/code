    StringBuilder builder = new StringBuilder();
    // Consider using File.OpenText
    using (StreamReader reader = new StreamReader("buf.txt", Encoding.ASCII))
    {
        string line;
        // Normally side-effect + test is ugly, but this is a common and
        // neat idiom
        while ((line = reader.ReadLine()) != null)
        {
            // TODO: What do you want to happen for empty lines?
            char segment = str[0];
            if (segment == 'A')
            {
                builder.Append(line);
            }
            else if (segment == 'B')
            {
                builder.Append("BET");
            }
        }
    }
    MessageBox.Show(builder.ToString());
