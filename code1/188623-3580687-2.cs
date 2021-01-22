    // Prepare.
    String url = "...";
    String sql = "SELECT name FROM people WHERE id = ?";
    int id = 123456;
    List<String> names = new ArrayList<String>();
    // Declare before try.
    Connection connection = null;
    PreparedStatement statement = null;
    ResultSet resultSet = null;
    try {
        // Acquire inside try.
        connection = DriverManager.getConnection(url);
        statement = connection.prepareStatement(sql); 
        statement.setInt(1, id);
        resultSet = statement.executeQuery();
        // Process results.
        while (resultSet.next()) {
            names.add(resultSet.getString("name"));
        }
    } finally { 
        // Close in reversed order in finally.
        if (resultSet != null) try { resultSet.close(); } catch (SQLException logOrIgnore) {}
        if (statement != null) try { statement.close(); } catch (SQLException logOrIgnore) {}
        if (connection != null) try { connection.close(); } catch (SQLException logOrIgnore) {}
    }
