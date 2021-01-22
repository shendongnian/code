    // Opens an encrypted database
    SQLiteConnection cnn = new SQLiteConnection("Data Source=c:\\test.db3;Password=mypassword");
    cnn.Open();
    // Removes the encryption on an encrypted database.
    cnn.ChangePassword(null);
