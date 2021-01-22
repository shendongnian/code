    public static bool OpenUri(string uri) {
      if (!Uri.IsWellFormedUriString(uri, UriKind.Absolute))
        return false;
      System.Diagnostics.Process.Start(uri);
      return true;
    }
