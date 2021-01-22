    public void DeleteMyObject(int objectId)
    {
        SqlConnection connectionOne = new SqlConnection("MyFirstDbConnection");
        SqlConnection connedtionTwo = new SqlConnection("MySecondDbCOnnection");
        SqlCommand myCommand = new SqlCommand(connectionOne);
        myCommand.CommandText = "DELETE FROM myTable where myid = " + objectId.ToString();
        connectionOne.Open();
        myCommand.ExecuteNonQuery();
        connectionOne.Close();
        myCommand.Connection = connectionTwo;
        connectionTwo.Open();
        myCommand.ExecuteNonQuery();
        connectionTwo.Close();
    }
