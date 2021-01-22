    // Get a temporary directory in which we can store the unmanaged DLL, with
    // this assembly's version number in the path in order to avoid version
    // conflicts in case two applications are running at once with different versions
    string dirName = Path.Combine(Path.GetTempPath(), "MyAssembly." +
      Assembly.GetExecutingAssembly().GetName().Version.ToString());
    if (!Directory.Exists(dirName))
      Directory.CreateDirectory(dirName);
    string dllPath = Path.Combine(dirName, "MyAssembly.Unmanaged.dll");
    // Get the embedded resource stream that holds the Internal DLL in this assembly.
    // The name looks funny because it must be the default namespace of this project
    // (MyAssembly.) plus the name of the Properties subdirectory where the
    // embedded resource resides (Properties.) plus the name of the file.
    using (Stream stm = Assembly.GetExecutingAssembly().GetManifestResourceStream(
      "MyAssembly.Properties.MyAssembly.Unmanaged.dll"))
    {
      // Copy the assembly to the temporary file
      try
      {
        using (Stream outFile = File.Create(dllPath))
        {
          const int sz = 4096;
          byte[] buf = new byte[sz];
          while (true)
          {
            int nRead = stm.Read(buf, 0, sz);
            if (nRead < 1)
              break;
            outFile.Write(buf, 0, nRead);
          }
        }
      }
      catch
      {
        // This may happen if another process has already created and loaded the file.
        // Since the directory includes the version number of this assembly we can
        // assume that it's the same bits, so we just ignore the excecption here and
        // load the DLL.
      }
    }
    // We must explicitly load the DLL here because the temporary directory 
    // is not in the PATH.
    // Once it is loaded, the DllImport directives that use the DLL will use
    // the one that is already loaded into the process.
    IntPtr h = LoadLibrary(dllPath);
    Debug.Assert(h != IntPtr.Zero, "Unable to load library " + dllPath);
