        using System.IO;
    
    string JPRO_8_5_0 = @"C:\ProgramData\Package Cache\{0809190b-37e7-4852-9f0c-e183636739ba}\JproSetup.exe";
    string JPRO_8_4_0 = @"C:\ProgramData\Package Cache\{270ce95e-5e84-4b6a-8d58-f8905b0a3cfc}\JproSetup.exe";
    try {
    if (File.Exists(JPRO_8_5_0))
    {
        Process a = new Process();
        a.StartInfo.FileName = JPRO_8_5_0;
        a.StartInfo.Arguments = "/uninstall /quiet";
        a.Start();
        MessageBox.Show("JPRO_8_5_0 Exists.");
    }
    if (File.Exists(JPRO_8_4_0))
    {
        Process b = new Process();
        b.StartInfo.FileName = JPRO_8_4_0;
        b.StartInfo.Arguments = "/uninstall /quiet";
        b.Start();
        MessageBox.Show("JPRO_8_4_0 Exists.");
    }
    else
    {
        MessageBox.Show("File Does Not Exists.");
    }
    }
    catch { }
