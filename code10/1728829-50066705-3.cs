    [Flags]
    enum Permissions 
    {
      None = 0x00,
      Read = 0x01,
      Write = 0x02,
      ReadWrite = 0x03,
      Delete = 0x04,
      ReadDelete = 0x05,
      WriteDelete = 0x06,
      ReadWriteDelete = 0x07
    }
    ...
    static Permissions GetPermission(bool read, bool write, bool delete) {
      var p1 = read ? Permissions.Read : Permissions.None;
      var p2 = write ? Permissions.Write : Permissions.None;
      var p3 = delete ? Permissions.Delete : Permissions.None;
      return p1 | p2 | p3;
    }
