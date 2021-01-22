    string[] all = System.Reflection.Assembly.GetEntryAssembly().
      GetManifestResourceNames();
    foreach (string one in all) {
        MessageBox.Show(one);
    }
