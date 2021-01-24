    private void buttonEnableMouseSonar_Click(object sender, EventArgs e)
    {
        SetMouseSonarEnabled(true);
    }
    
    private void buttonDisableMouseSonar_Click(object sender, EventArgs e)
    {
        SetMouseSonarEnabled(false);
    }
    
    
    [DllImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool SystemParametersInfo(uint uiAction, uint uiParam, uint pvParam, uint fWinIni);
    
    private void SetMouseSonarEnabled(bool enable)
    {
        const uint SPI_SETMOUSESONAR = 0x101D;
        const uint SPIF_UPDATEINIFILE = 0x01;
        const uint SPIF_SENDCHANGE = 0x02;
    
        if(!SystemParametersInfo(SPI_SETMOUSESONAR, 0, (uint)(enable ? 1 : 0), SPIF_UPDATEINIFILE | SPIF_SENDCHANGE))
        {
            throw new Win32Exception();
        }
    }
