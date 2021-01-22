      public void UpdateAppSettings(string key, string value)
      {
        using (XmlDocument xmlDoc = new XmlDocument())
        {
          xmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
          xmlDoc.DocumentElement.FirstChild.SelectSingleNode("descendant::"+key).Attributes[0].Value = value;
          xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
        }
        System.Configuration.ConfigurationManager.RefreshSection("section/subSection");
      }
