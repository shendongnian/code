    string type = null, title = null, mediaType = null;
    int? year, length;
    string[] authors = new string[0];
    // The parts[0] == string.Empty ? 1 : 0 is caused by the "strangeness" of Regex.Split
    // that can add an empty element at the beginning of the string
    for (int i = parts[0] == string.Empty ? 1 : 0; i < parts.Length; i += 2)
    {
        string key = parts[i].TrimEnd();
        string value = parts[i + 1].Trim();
        Console.WriteLine("[{0}|{1}]", key, value);
        switch (key)
        {
            case "Type:":
                type = value;
                break;
            case "Year:":
                {
                    int temp;
                    if (int.TryParse(value, out temp))
                    {
                        year = temp;
                    }
                }
                break;
            case "Title:":
                title = value;
                break;
            case "Authors:":
                {
                    authors = value.Split(" ; ");
                }
                break;
            case "Length:":
                {
                    int temp;
                    if (int.TryParse(value, out temp))
                    {
                        length = temp;
                    }
                }
                break;
            case "Media Type:":
                mediaType = value;
                break;
        }
    }
