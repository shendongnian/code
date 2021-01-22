      SavedEventSet sES;
      OpenFileDialog oFD = new OpenFileDialog();
      Stream stream = null;
      BinaryFormatter bF;
      try
      {
        oFD.InitialDirectory = this.path;
        oFD.Title = "Open Event Saved File.";
        oFD.ShowDialog();
        if (oFD.FileName.Contains(".sav"))
        {
          stream = File.Open(oFD.FileName, FileMode.Open);
          bF = new BinaryFormatter();
          sES = (SavedEventSet)bF.Deserialize(stream);
          stream.Close();
        }
      }
      catch (Exception ex)
      {
        if (stream != null)
          stream.Close();
        /*handle Exception*/
      }
