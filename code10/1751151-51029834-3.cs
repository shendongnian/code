    public void LaunchRPGApp(Application program)
    {
        MakeMacro(program);
        const string wsPathAndFilename =
            "C:\\Program Files (x86)\\IBM\\Client Access\\Emulator\\Private\\flast1.ws";
        var processInfo = new ProcessStartInfo("pcsws.exe")
        {
            Arguments = "{wsPathandFilename} /M=name.mac"
        };
        Process.Start(processInfo);
    }
    private void MakeMacro(Application program)
    {
        var macroText = GetMacroText(program);//Method to get the content of the macro
        var fileName =
            $"C:\\Users\\{Environment.UserName}\\AppData\\Roaming\\IBM\\Client Access\\Emulator\\private\\name.mac";
        using (var writer = new StreamWriter(fileName))
        {
            writer.Write(macroText);
        }
    }
