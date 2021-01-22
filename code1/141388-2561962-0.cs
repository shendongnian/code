        private string defaultPdfProg()
        { //Returns the default program for opening a .pdf file; On Fail returns empty string. 
          // (see notes below) 
            string retval = "";
            
            RegistryKey pdfDefault = Registry.ClassesRoot.OpenSubKey(".pdf").OpenSubKey("OpenWithList");
            string[] progs = pdfDefault.GetSubKeyNames();
            if (progs.Length > 0)
            {
                retval = progs[1];
                string[] pieces = retval.Split('.'); // Remove .exe
                
                if (pieces.Length > 0)
                {
                    retval = pieces[0];
                }
            }
            return retval;
        }
        private void browserIntegration(string defaultPdfProgram)
        { //Test if browser integration is enabled for Adobe Acrobat (see notes below)
            RegistryKey reader = null;
            string[] vers = null;
            if (defaultPdfProgram.ToLower() == "acrobat")
            { //Default program is Adobe Acrobat
                reader = Registry.LocalMachine.OpenSubKey("Software").OpenSubKey("Adobe").OpenSubKey("Adobe Acrobat");
                vers = reader.GetSubKeyNames();
            }
            else if (defaultPdfProgram.ToLower() == "acrord32")
            { //Default program is Adobe Acrobat Reader
                reader = Registry.LocalMachine.OpenSubKey("Software").OpenSubKey("Adobe").OpenSubKey("Acrobat Reader");
                vers = reader.GetSubKeyNames();
            }
            else
            {
                //TODO: Handle non - adobe .pdf default program
            }
             
            if (vers.Length > 0)
            {
                string versNum = vers[vers.Length - 1].ToString();
                reader = reader.OpenSubKey(versNum);
                reader = reader.OpenSubKey("AdobeViewer",true);
                Boolean keyExists = false;
                Double keyValue = -1;
                foreach(string adobeViewerValue in reader.GetValueNames())
                {
                    if (adobeViewerValue.Contains("BrowserIntegration"))
                    {
                        keyExists = true;
                        keyValue = Double.Parse(reader.GetValue("BrowserIntegration").ToString());
                    }
                }
                if (keyExists == false || keyValue < 1)
                {
                    string message = "This application requires a setting in Adobe to be changed. Would you like to attempt to change this setting automatically?";
                    DialogResult createKey = MessageBox.Show(message, "Adobe Settings", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (createKey.ToString() == "OK")
                    {
                        reader.SetValue("BrowserIntegration", 1, RegistryValueKind.DWord);
                        //test to make sure registry value was set
                    }
                    if (createKey.ToString() == "Cancel")
                    {
                        //TODO: Provide instructions to manually change setting
                    }
                }
            }
        }
