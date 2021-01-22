    static void StartOSK()
    {
      string windir = Environment.GetEnvironmentVariable("WINDIR");
      string osk = null;
      if (osk == null)
      {
        osk = Path.Combine(Path.Combine(windir, "sysnative"), "osk.exe");
        if (!File.Exists(osk))
        {
          osk = null;
        }
      }
      if (osk == null)
      {
        osk = Path.Combine(Path.Combine(windir, "system32"), "osk.exe");
        if (!File.Exists(osk))
        {
          osk = null;
        }
      }
      if (osk == null)
      {
        osk = "osk.exe";
      }
      Process.Start(osk);
    }
