    string text = "";
    for (int i = 0; i < data.Items.Count; i++)
    {
        text += data.Items[i].ToString();
        if(i < data.Items.Count - 1)
            text += ", ";
    }
    writer.WriteLine(text);
