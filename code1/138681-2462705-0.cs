    Private Sub CheckConfigFile()
        Dim config As System.Configuration.Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
        Dim sec As ConfigurationSection = config.AppSettings
        If sec IsNot Nothing Then
            If sec.SectionInformation.IsProtected = False Then
                Debug.Write("Encrypting the application settings...")
                sec.SectionInformation.ProtectSection(String.Empty)
                sec.SectionInformation.ForceSave = True
                config.Save(ConfigurationSaveMode.Full)
                Debug.WriteLine("done!")
            End If
        End If
    End Sub
