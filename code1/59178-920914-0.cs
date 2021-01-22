    try
    {
    SqlConnection connection = new SqlConnection(DB("Your DB Name"));
    connection.Open();
    }
    catch (Exception ex)
    {
    // check the exception message here, if it's telling you that the db is not available. then 
    //write to xml file.
        WriteToXml();   
    }
    finally
    {
      connection.Close();
    }
