    public void OpenNotepad()
    {
        Clipboard.SetText("All your text");
    
        Process process = Process.Start("notepad.exe");
        process.WaitForInputIdle();
        SetForegroundWindow(process.MainWindowHandle);
        SendKeys.Send("^V");
    }
