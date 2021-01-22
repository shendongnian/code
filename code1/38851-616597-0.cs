    string s = "replace\nnewlines\nwith\nbreaks";
    string[] lines = s.Split('\n');
    for (int i=0; i<lines.Length; i++)
    {
        xw.WriteString(lines[i]);
        if (i<lines.Length - 1)
        {
            xw.WriteElementString("br", "", "");
        }
    }
