    string[] lines = File.ReadAllLines(@"pathtofile");
    int Object = 0;
    for (int i = 0; i < lines.Length; i++)
    {
        if (lines[i].Contains("Object"))
        {
            MessageBox.Show("contain!");
            dsObject++;
        }
    
        if (Object == 1)
        {
            lines[i]=lines[i].Replace("Object", String.Empty);
            MessageBox.Show(lines[i]);
        }
    
        File.AppendAllText(@"savefile.txt", lines[i] + Environment.NewLine);
        string result = lines[i];
    }
