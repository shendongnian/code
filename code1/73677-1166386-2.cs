    // Create connection, command, etc objects.
    SQLiteConnection conn;
    try {
      conn = new SQLiteConnection("Data Source=" + filepath + ";Version=3;");
      // Do Stuff here...
    }
    catch (exception e) {
      // Although there are arguments to say don't catch generic exceptions,
      // but instead catch each explicit exception you can handle.
    }
    finally {
      // Check for null, and if not, close and dispose
      if (null != conn)
        conn.Dispose();
    }
