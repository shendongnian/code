    public static DateTime? GetBuildDateTime(this Assembly assembly)
    {
        var path = new Uri(assembly.GetName().CodeBase).LocalPath;
        if (!File.Exists(path)) return null;
        var headerDefinition = typeof (_IMAGE_FILE_HEADER);
        var buffer = new byte[Math.Max(Marshal.SizeOf(headerDefinition), 4)];
        using (var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            fileStream.Position = 0x3C;
            fileStream.Read(buffer, 0, 4);
            fileStream.Position = BitConverter.ToUInt32(buffer, 0); // COFF header offset
            fileStream.Read(buffer, 0, 4); // "PE\0\0"
            fileStream.Read(buffer, 0, buffer.Length);
        }
        var pinnedBuffer = GCHandle.Alloc(buffer, GCHandleType.Pinned);
        try
        {
            var addr = pinnedBuffer.AddrOfPinnedObject();
            var coffHeader = (CoffHeader)Marshal.PtrToStructure(addr, headerDefinition);
            var epoch = new DateTime(1970, 1, 1);
            var sinceEpoch = new TimeSpan(coffHeader.TimeDateStamp * TimeSpan.TicksPerSecond);
            var buildDate = epoch + sinceEpoch;
            var localTime = TimeZone.CurrentTimeZone.ToLocalTime(buildDate);
            return localTime;
        }
        finally
        {
            pinnedBuffer.Free();
        }
    }
