    try{
       Connection connection = ConnectionManager.openConnection();
       try{
           //work with the connection;
       }finally{
           if(connection != null){
              connection.close();           
           }
       }
    }catch(ConnectionException connectionException){
       //handle connection exception;
    }
