    // Opens an unencrypted database
    SQLiteConnection cnn = new SQLiteConnection("Data Source=c:\\test.db3");
    cnn.Open();
    // Encrypts the database. The connection remains valid and usable afterwards.
    cnn.ChangePassword("mypassword");
