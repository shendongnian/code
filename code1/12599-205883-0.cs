    Connection con = DriverManager.getConnection(url, "***", "***");
    try {
        PreparedStatement pStmt = con.prepareStatement("your query here");
        ... // query the database and get the results
    }
    catch(ClassNotFoundException cnfe) {
        // real exception handling goes here
    }
    catch(SQLException sqle) {
        // real exception handling goes here
    }
    finally {
        try {
            con.close();
        }
        catch {
            // What do you do here?
        }
    }
