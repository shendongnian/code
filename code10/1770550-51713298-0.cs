        void Start()
    {
        f = new FileInfo(Application.persistentDataPath + @"\save.txt");
        
        //Load existing username options here
        if (f.Exists)
        {
            Load();
        }
        Save();
        Load();
    }
        void Save()
    {
        StreamWriter w = new StreamWriter(Application.persistentDataPath + @"\save.txt", false);
            for (int i = 0; i < menuOptions.Count; i++)
            {
                w.WriteLine(menuOptions[i]);
            }
        w.Close();
    }
        void Load()
    {
        f = new FileInfo(Application.persistentDataPath + @"\save.txt");
        if (f.Exists && selectedUsername != null) //don't know why selectedUsername sometimes comes up as null, but that additional condition was needed
        {
            selectedUsername.ClearOptions();
            selectedUsername.AddOptions(new List<string> { "" });
            StreamReader r = new StreamReader(Application.persistentDataPath + @"\save.txt");
            string line;
            menuOptions.Clear();
            while ((line = r.ReadLine()) != null)
            {
                menuOptions.Add(line);
                selectedUsername.AddOptions(new List<string> { line });
            }
            selectedUsername.RefreshShownValue();
            r.Close();
        }
    }
