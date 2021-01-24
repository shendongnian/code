    foreach (var itemCollection in sFTPs)
    {
        // iniFile.Sections[0] <-- always overrides the same section
    	iniFile.Sections[0].Keys[0].Value = itemCollection.Address;
    	iniFile.Sections[0].Keys[1].Value = itemCollection.Port;
    	iniFile.Sections[0].Keys[2].Value = itemCollection.UserName;
    	iniFile.Sections[0].Keys[3].Value = itemCollection.Password;
    	iniFile.Sections[0].Keys[4].Value = "SFTP";
    	iniFile.Sections[0].Keys[5].Value = itemCollection.Folder;
    }
