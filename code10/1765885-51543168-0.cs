        if (JPRO_8_5_0 != null)
        {
            Process a = new Process();
            a.StartInfo.FileName = JPRO_8_5_0;
            a.StartInfo.Arguments = "/uninstall /quiet";
            a.Start();
        }
        if (JPRO_8_4_0 != null)
        {
            Process b = new Process();
            b.StartInfo.FileName = JPRO_8_4_0;
            b.StartInfo.Arguments = "/uninstall /quiet";
            b.Start();
        }
