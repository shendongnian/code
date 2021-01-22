    // Opens an encrypted database by calling SetPassword()
    SQLiteConnection cnn = new SQLiteConnection("Data Source=c:\\test.db3");
    cnn.SetPassword(new byte[] { 0xFF, 0xEE, 0xDD, 0x10, 0x20, 0x30 });
    cnn.Open();
    // The connection is now usable
