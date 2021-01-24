    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        //Assigning the current selected index of combobox to serialize class.
        SaveComboSettings f1 = new SaveComboSettings();
        f1.cmb1SelectedIndex = this.comboBox1.SelectedIndex;
        f1.cmb2SelectedIndex = this.comboBox2.SelectedIndex;
        //Serialize
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fsout = new FileStream("ComboBoxSettings.binary", FileMode.Create, FileAccess.Write, FileShare.None);
        try
        {
            using (fsout)
            {
                bf.Serialize(fsout, f1);                   
            }
        }
        catch (Exception Ex)
        {
            //Some Exception occured
        }  
    }
