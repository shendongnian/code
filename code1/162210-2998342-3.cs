    Version version = Assembly.GetExecutingAssembly().GetName().Version;
      
    this.Text = "My Cool Product - Version " + version;
    // or with a fancier formatting
    this.Text = string.Format("My Cool Product - Version {0}.{1}.{2} Revision {3}", 
        version.Major, version.Minor, version.Build, version.Revision);
