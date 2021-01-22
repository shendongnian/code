    public static MachineType GetDllMachineType(string dllPath)
    {
        // See http://www.microsoft.com/whdc/system/platform/firmware/PECOFF.mspx
        // Offset to PE header is always at 0x3C.
        // The PE header starts with "PE\0\0" =  0x50 0x45 0x00 0x00,
        // followed by a 2-byte machine type field (see the document above for the enum).
        //
        FileStream fs = new FileStream(dllPath, FileMode.Open, FileAccess.Read);
        BinaryReader br = new BinaryReader(fs);
        fs.Seek(0x3c, SeekOrigin.Begin);
        Int32 peOffset = br.ReadInt32();
        fs.Seek(peOffset, SeekOrigin.Begin);
        UInt32 peHead = br.ReadUInt32();
        if (peHead!=0x00004550) // "PE\0\0", little-endian
            throw new Exception("Can't find PE header");
        MachineType machineType = (MachineType) br.ReadUInt16();
        br.Close();
        fs.Close();
        return machineType;
    }
