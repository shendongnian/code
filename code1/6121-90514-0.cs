    SqlCommand myCMD = new SqlCommand("SELECT CategoryID, CategoryName FROM Categories;" +
                                      "SELECT EmployeeID, LastName FROM Employees", nwindConn);
    nwindConn.Open();
    
    SqlDataReader myReader = myCMD.ExecuteReader();
    
    do
    {
      Console.WriteLine("\t{0}\t{1}", myReader.GetName(0), myReader.GetName(1));
    
      while (myReader.Read())
        Console.WriteLine("\t{0}\t{1}", myReader.GetInt32(0), myReader.GetString(1));
    
    } while (myReader.NextResult());
    
    myReader.Close();
    nwindConn.Close();
