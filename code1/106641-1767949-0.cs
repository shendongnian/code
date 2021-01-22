    <%
    // Get user's query
    string query = Request.Form["query"]; // or Request.QueryString for data from the querystring
    // Connect to the database    
    string connString = "your connection string";
    System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(connString);
    System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand(query, conn);
    // Read your data however you like
    System.Data.SqlClient.SqlDataReader reader = command.ExecuteReader();
    while (reader.Read()) {
        // Deal with your data here
        Response.Write(reader.GetString(0));
    }
    
    %>
