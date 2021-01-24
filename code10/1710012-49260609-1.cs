    -- Database
    CREATE PROCEDURE schema.sproc_CommandBatch (
        -- any variables here
    ) AS
    BEGIN
        -- query 1
        -- query 2
        -- query 3
    END
    GO
    // C#
    using (SqlConnection con = new SqlConnection(connectionString)) {
        con.Open();
        using (SqlCommand cmd = new SqlCommand("schema.sproc_CommandBatch", con)) {
            // cmd.CommandType = CommandType.StoredProcedure
            // add any parameters
            // Execute()
        }
        con.Close();
    }
