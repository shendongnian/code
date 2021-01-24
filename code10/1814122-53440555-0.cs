    string inputName = "id=4 issue=critical level project=ABC group=Group A";
    string[] values = inputName.Split(' ');
    List<string> output = new List<string>();
    for (int i = 0; i < values.Length -1; i++)
    {
        if (values[i].Contains('=') && !values[i + 1].Contains('='))
        {
             output.Add(values[i] + ' ' +values[i + 1]);
        }
        else if (!values[i].Contains('='))
        {
        }
        else
        {
            output.Add(values[i]);
        }
    }
    string[] requiredValues = output.ToArray();
