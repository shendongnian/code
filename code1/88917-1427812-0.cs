        using (Stream fs = new FileStream(@"D:\xxx\Shell\Config\Game.cfg.bak", FileMode.Create, FileAccess.Write, FileShare.None, 0x1000, FileOptions.WriteThrough))
        using (StreamWriter shellConfigWriter = new StreamWriter(fs))
        {
            for (int i = 0; i < configContents.Count; i++)
            {
                shellConfigWriter.WriteLine(configContents[i]);
            }
            shellConfigWriter.Flush();
            shellConfigWriter.BaseStream.Flush();
        }
