    StringBuilder sb = new StringBuilder();
    sb.Append(Path.GetFileNameWithoutExtension(Application.ExecutablePath));
    sb.Append("_");
    sb.Append(DateTime.Now.ToString("yyyyMMddHHmmssFF"));
    sb.Append(".dmp");
    string dmpFilePath = Path.Combine(Path.GetTempPath(), sb.ToString());
    ClrDump.RegisterFilter(_dmpFilePath, ClrDump.MINIDUMP_TYPE.MiniDumpNormal);
