    try
    {
      oFD.InitialDirectory = this.path;
      oFD.Title = "Open Event Saved File.";
      oFD.ShowDialog();
      if(oFD.FileName.Contains(".sav"))
      {
        stream = File.Open(oFD.FileName, FileMode.Open);
        bF = new BinaryFormatter();
        sES = (SavedEventSet)bF.Deserialize(stream);
      }
    }
    catch (Exception ex)
    {
      /*handle Exception*/
    }
    finally
    {
      if (stream != null)
        stream.Close();
    }
