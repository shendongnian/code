    public ConfigForm()
    {
        InitializeComponent();
        cm = new ConfigManager();
        ser = new XmlSerializer(typeof(ConfigManager));
        LoadConfig();
    }
    private void LoadConfig()
    {     
        try
        {
            if (File.Exists(filepath))
            {
                FileStream fs = new FileStream(filepath, FileMode.Open);
                cm = (ConfigManager)ser.Deserialize(fs);
                fs.Close();
            } 
            else
            {
                MessageBox.Show("Could not find User Configuration File\n\nCreating new file...", "User Config Not Found");
                FileStream fs = new FileStream(filepath, FileMode.CreateNew);
                TextWriter tw = new StreamWriter(fs);
                ser.Serialize(tw, cm);
                tw.Close();
                fs.Close();
            }    
            setupControlsFromConfig();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
