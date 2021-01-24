    public Form1()
    {
        InitializeComponent();
        DeserializeFormSettings();
    }
    public void DeserializeFormSettings()
    {          
        BinaryFormatter bf = new BinaryFormatter();
         FileStream fsin;
        if(File.Exists("ComboBoxSettings.binary"))
            fsin = new FileStream("ComboBoxSettings.binary", FileMode.Open, FileAccess.Read, FileShare.None);
        else
            return;
        try
        {
            using (fsin)
            {
                SaveComboSettings f1 = (SaveComboSettings)bf.Deserialize(fsin);
                this.comboBox1.SelectedIndex = f1.cmb1SelectedIndex;
                this.comboBox2.SelectedIndex = f1.cmb2SelectedIndex;
            }
        }
        catch(Exception Ex)
        {
            // "An error has occured";  
        }
    }
