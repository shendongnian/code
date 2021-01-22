    if(Platform.Equals("WinCE"))
    {
        m_CurrentPath = Path.GetDirectoryName(
                          Assembly.GetExecutingAssembly().GetName().CodeBase);
    }
    else if(Platform.Equals("Win32NT"))
    {
        m_CurrentPath = Directory.GetCurrentDirectory();
    }
