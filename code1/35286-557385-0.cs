    public static void FindAll()
    {
    List<Books> books = new List<books>();
    using (Sqlconnection conn = new sqlconnection(connstring))
    using (sqlcommand cmd = new SqlCommand("select title, available from book ", conn)
    {
      SqlDatareader dr = cmd.executereader()
      while (dr.read())
      {
        books.add(new Book(dr["title"], dr["avail"])
      }
    
    }
    
    foreach(Book curBook in Book.FindAll())
      { /* do something with book */ }
    
    }
