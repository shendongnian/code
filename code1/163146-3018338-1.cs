    // Returns -1, corresponding to FF FF FF FF
    int header = reader.ReadInt32();
    // Returns 0x49, for packet type
    byte packetType = reader.ReadByte();
    // Returns 15, for version
    byte ver = reader.ReadByte();
    // Returns "Lokalen TF2 #03 All maps | Vanilla"
    string serverName = reader.ReadSteamString();
    // Returns "cp_well"
    string mapName = reader.ReadSteamString();
    // etc.
You can use similar code for creating your request packets, using a BinaryWriter instead of manually assembling individual byte values.
