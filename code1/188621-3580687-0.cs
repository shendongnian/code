    // Prepare.
    String myConnectionString = "...";
    String mySql = "select name from people where id = ?";
    int myId = 123456;
    List<String> fields = new ArrayList<String>();
    // Declare before try.
    Connection connection = null;
    PreparedStatement statement = null;
    ResultSet resultSet = null;
    try {
        // Acquire inside try.
        connection = DriverManager.getConnection(myConnectionString);
        statement = connection.prepareStatement(mySql); 
        statement.setInt(1, myId);
        resultSet = statement.executeQuery();
        // Process results.
        while (resultSet.next()) {
            fields.add(resultSet.getString(1));
        }
    } finally { 
        // Close in reversed order in finally.
        if (resultSet != null) try { resultSet.close(); } catch (SQLException logOrIgnore) {}
        if (statement != null) try { statement.close(); } catch (SQLException logOrIgnore) {}
        if (connection != null) try { connection.close(); } catch (SQLException logOrIgnore) {}
    }
