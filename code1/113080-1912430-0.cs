        SharedSettings settings = new SharedSettings();
        settings.RelScript = this.txtRelScript.Text;
        settings.URL = this.txtURL.Text;
        settings.DestUser = this.txtDestUser.Text;
        XmlSerializer dehydrator = new XmlSerializer(settings.GetType());
        using (System.IO.FileStream fs = new FileStream(this.configFilePath, FileMode.OpenOrCreate))
        {
            dehydrator.Serialize(fs, settings);
        }
