    void MyRead(Context c) 
    {
      lock(c.P) { database.Read(c); }
    }
    void MyWrite(Context c)
    {
      lock(c.P) { database.Write(c); }
    }
