    private void browserIntegration(string defaultPdfProgram)
        {
            try
            {
                RegistryKey reader = null;
                string[] vers = null;
                #region Walters Versuch
                reader = Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("Adobe");
                reader = reader.OpenSubKey("Acrobat Reader");
                vers = reader.GetSubKeyNames();
                if (vers.Contains<string>("9.0"))
                {
                    reader = reader.OpenSubKey("9.0");
                    reader = reader.OpenSubKey("Originals", true);
                    if (reader.GetValueNames().Contains<string>("bBrowserIntegration"))
                        reader.SetValue("bBrowserIntegration", 1, RegistryValueKind.DWord);
                    // wenn der Key fehlt ist Browserintegration auch angeschaltet
                    // alternativ: reader.DeleteSubKey("bBrowserIntegration", false);
                }
                else
                    MessageBox.Show(
                        "In case you run into problems later, please make sure yourself to select\n'Show PDF in Browser' in Acrobat Reader's Settings"
                        , "Unknown Version of Acrobat Reader");
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace
                    + "\nIn case you run into problems later, please make sure yourself to select\n'Show PDF in Browser' in Acrobat Reader's Settings"
                    , "Error while switching on 'Browserintegration' in 'Acrobat Reader'");
            }
    }
