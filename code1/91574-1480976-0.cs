    ApplicationSettings.Instance.Name = "MyApplicationName";
    ApplicationSettings.Instance.Description = "It's an awesome application";
    ApplicationSettings.Instance.Theme = "LoveThemeofMGS";
    ApplicationSettings.Instance.Save();
    testlabel.Text = ApplicationSettings.Instance.Name;
    testlabel2.Text = ApplicationSettings.Instance.Description;
 
