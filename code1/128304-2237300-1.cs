    public Entity find(Long id) throws SQLException {
        Connection connection = null;
        PreparedStatement statement = null;
        ResultSet resultSet = null;
        Entity entity = null;
    
        try {
            connection = database.getConnection();
            statement = connection.prepareStatement(SQL_FIND);
            statement.setLong(1, id);
            resultSet = statement.executeQuery();
    
            if (resultSet.next()) {
                entity = new Entity();
                entity.setProperty(resultSet.getObject("columnname"));
                // etc..
            }
        } finally {
            // Always free resources in reversed order.
            if (resultSet != null) try { resultSet.close(); } catch (SQLException logOrIgnore) {}
            if (statement != null) try { statement.close(); } catch (SQLException logOrIgnore) {}
            if (connection != null) try { connection.close(); } catch (SQLException logOrIgnore) {}
        }
    
        return entity;
    }
