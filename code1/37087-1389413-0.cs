        private void SettingsForm_Load(object sender, EventArgs e)
        {
       // load default language to the list
            languageList.Add(new Language("English", "en"));
            string fileName = "myProgram.resources.dll";
       
       // load other languages available in the folder
            DirectoryInfo di = new DirectoryInfo(Application.StartupPath);
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                if (File.Exists(dir.FullName + "\\" + fileName))
                {
                    try
                    {
                        CultureInfo ci = new CultureInfo(dir.Name);
                        languageList.Add(new Language(ci.NativeName, ci.Name));
                    }
                    catch
                    {
                        // whatever happens just don't load the language and proceed ;)
                        continue;
                    }
                }
            }
        }
