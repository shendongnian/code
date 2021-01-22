    iTunesLib.IiTunes iTunesApp;
    iTunesApp = new iTunesLib.iTunesAppClass();
    iTunesLib.IITSourceCollection iSources = iTunesApp.Sources;
    foreach (iTunesLib.IITSource iSource in iSources)
    {
      if (iSource.Kind.Equals(iTunesLib.ITSourceKind.ITSourceKindSharedLibrary))
      {
        //Do AwesomeStuffHere!
      }
    }
