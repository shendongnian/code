    sqlite3* db;
    sqlite3_open("some.db", &db);
    try
    {
        sqlite3_stmt* stmt;
        sqlite3_prepare_v2(db, "SELECT * FROM foo;", &stmt);
        try
        {
            // Lots of stuff...
            try
            {
                make_changes_with(stmt);
    
                // More stuff...
            }
            catch( Exception e )
            {
                rollback_to(current_state);
                throw;
            }
        }
        finally
        {
            sqlite3_finalize(stmt);
        }
    }
    finally
    {
        sqlite3_close(db);
    }
