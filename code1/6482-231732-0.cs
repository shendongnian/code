    public void methodWithDynamicallyGeneratedSQL() throws SQLException {
        String sql = ...; // Generate some SQL
        try {
            ... // Try running the query
        }
        catch (SQLException ex) {
            // Don't bother to log the stack trace, that will
            // be printed when the exception is handled for real
            logger.error(ex.toString()+"For SQL: '"+sql+"'");
            throw ex;  // Handle the exception long after the SQL is gone
        }
    }
