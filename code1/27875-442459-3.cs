    PerformanceCounter bytesSentPerformanceCounter= new PerformanceCounter();
    bytesSentPerformanceCounter.CategoryName = ".NET CLR Networking";
    bytesSentPerformanceCounter.CounterName = "Bytes Sent";
    bytesSentPerformanceCounter.InstanceName = GetInstanceName();
    bytesSentPerformanceCounter.ReadOnly = true;
    
    float bytesSent = bytesSentPerformanceCounter.NextValue();
    //....
    private static string GetInstanceName()
    {
      // Used Reflector to find the correct formatting:
      string assemblyName = GetAssemblyName();
      if ((assemblyName == null) || (assemblyName.Length == 0))
      {
        assemblyName = AppDomain.CurrentDomain.FriendlyName;
      }
      StringBuilder builder = new StringBuilder(assemblyName);
      for (int i = 0; i < builder.Length; i++)
      {
        switch (builder[i])
        {
          case '/':
          case '\\':
          case '#':
            builder[i] = '_';
            break;
          case '(':
            builder[i] = '[';
            break;
          case ')':
            builder[i] = ']';
            break;
        }
      }
      return string.Format(CultureInfo.CurrentCulture, 
                           "{0}[{1}]", 
                           builder.ToString(), 
                           Process.GetCurrentProcess().Id);
    }
    private static string GetAssemblyName()
    {
      string str = null;
      Assembly entryAssembly = Assembly.GetEntryAssembly();
      if (entryAssembly != null)
      {
        AssemblyName name = entryAssembly.GetName();
        if (name != null)
        {
          str = name.Name;
        }
      }
      return str;
    }
