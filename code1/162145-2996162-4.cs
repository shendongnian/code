    /// <summary>
    /// Binds the server configurations to the specified grid view.
    /// </summary>
    public void BindConfiguration(DataGridView gridView) {
      if (gridView == null)
        throw new ArgumentNullException("gridView");
      var config = ServerConfigurationSection.GetConfiguration();
      if (config != null) {
        gridView.DataSource = config.Servers.Cast<ServerConfigurationElement>().ToList();
      }
    }
