    public static void MyFunction(string ogContent, TextBox t)
    {
        List<string> splitCheckedContents = new List<string>();
        string[] splitContents = ogContent.Split(ogContent.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
        for (int j = 0; j < splitContents.Length; j++)
        {
            string stackString = "";
            do
            {
                stackString = stackString + "\\n" + splitContents[j++].Replace("\"", "\\\"");
            } while (j < splitContents.Length && (stackString.Length + splitContents[j].Length + 2) < 4500);
            splitCheckedContents.Add(stackString);
        }
        t.Text = "";
        foreach (string s in splitCheckedContents)
        {
            t.Text += s;
        }
    }
