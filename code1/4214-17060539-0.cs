    ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
    Assembly asm = Assembly.GetCallingAssembly();
    String path = Path.GetDirectoryName(new Uri(asm.EscapedCodeBase).LocalPath);
            
    string strLog4NetConfigPath = System.IO.Path.Combine(path, "log4net.config");
