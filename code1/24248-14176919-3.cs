    string comboboxFileName = @"c:\workDir\settings.settings";
    private void saveComboboxInFile (String comboboxFileName )
    {
       //--------------------------------------------------------
       //- Store the combobox values in a file. 1 value = 1 line
       //--------------------------------------------------------
       try
        {
            using (StreamWriter comboboxsw = new StreamWriter(comboboxFileName))
            {
                foreach (var cfgitem in comboBox.Items)
                {
                    comboboxsw.WriteLine(cfgitem);
                }
            } // End Using`
        }
        catch (Exception e)
        {
           //process exception
        }
    }
   
    private void reloadCombboxFromFile (string  comboboxFileName )
       {
        //-------------------------------------------------
        //- Read the values back into the combobox
        //------------------------------------------------- 
            try
            {
                using (StreamReader comboboxsr = new StreamReader(comboboxFileName))
                {
                     while (!comboboxsr.EndOfStream)
                     {
                          string itemread = comboboxsr.ReadLine();
                          comboBox.Items.Add(itemread);
                     }
                } // End Using
          }
          catch (DirectoryNotFoundException dnf)
          {
             // Exception Processing
          }
          catch (FileNotFoundException fnf)
          {
             // Exception Processing
          }
          catch (Exception e)
          {
             // Exception Processing
          }
       }
