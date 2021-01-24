    try
    {
        const string FILENAME = "TAInput.ini";
        string text = File.ReadAllText(FILENAME);
        const string DEADZONE = @"(DeadZone=0\.)\d[\d.]*";
        var result = Regex.Replace(text, DEADZONE, $"$1{nudInput.Value.ToString()}\n");
        File.WriteAllText(FILENAME, text);
        Process.Start(FILENAME);
    }
    catch
    {
         MessageBox.Show("No");
    }
