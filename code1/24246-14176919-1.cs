       //--------------------------------------------------------
       //- Store the combobox values in a file. 1 value = 1 line
       //--------------------------------------------------------
       try
        {
            //save comboBox
            string comboboxFileName = "examplecombobox.cfg");
            using (StreamWriter comboboxsw = new StreamWriter(comboboxFileName))
            {
                foreach (var cfgitem in comboBox.Items)
                {
                    comboboxsw.WriteLine(cfgitem);
                }
            } // End Using`
    
    //-------------------------------------------------
    //- Read the values back into the combobox
    //------------------------------------------------- 
        try
        {
            string comboboxFileName = "examplecombobox.cfg";
            using (StreamReader comboboxsr = new StreamReader(comboboxFileName))
            {
                 while (!comboboxsr.EndOfStream)
                 {
                      string itemread = comboboxsr.ReadLine();
                      comboBox.Items.Add(cfgitemread);
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
