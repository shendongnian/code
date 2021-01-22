    static RegistryKey fontsKey =
        Registry.LocalMachine.OpenSubKey(
            @"Software\Microsoft\Windows NT\CurrentVersion\Fonts");
    static public string GetFontFile(string fontName)
    {
        return fontsKey.GetValue(fontName, string.Empty) as string;
    }
