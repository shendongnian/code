    private static Dictionary<string, string> replacements = new Dictionary<string, string>
    {
        { "Mode1A", "M1A" },
        { "Mode1B", "M1B" },
        { "Mode1", "M1" },
        { "Mode2", "M2" },
        { "Mode3", "M3" },
        { "Mode6", "M6" },
        { "Read DTCs", "Read" },
        { "Clear DTCs", "Clear" },
        { "EPB_APPL-REL", "EPB" },
        { "POWER_DOWN", "PWRD" }
    };
    private void button2_Click(object sender, EventArgs e)
    {
        ChangeFolderNames();
    }
    private void ChangeFolderNames()
    {
        foreach(KeyValuePair<string, string> pair in replacements)
            Replace(strpath, pair.Key, pair.Value);
    }
    public static void Replace(string path, string from, string to)
    {
        string[] folders = System.IO.Directory.GetDirectories(path, "*", System.IO.SearchOption.TopDirectoryOnly);
        foreach (string folder in folders)
        {
            // recursively rename all subfolders first
            Replace(folder, from, to);
            string prefix = path;
            string newFolderName = prefix + folder.Substring(prefix.Length).Replace(from, to);
            
            if (newFolderName != folder_
                System.IO.Directory.Move(folder, newFolderName);
        }
    }
