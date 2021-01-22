    string url ;
    try 
         { 
                // statements 
                try 
                { 
                } 
                catch(SqlException sqlex) 
                { 
                   url = @"~/Error.aspx?err=" + Server.UrlEncode(sqlex.Message) + "&src=" + Server.UrlEncode(sqlex.ToString()); 
                } 
                catch (Exception ex) 
                { 
                    url = @"~/Error.aspx?err=" + Server.UrlEncode(ex.Message) + "&src=" + Server.UrlEncode(ex.ToString()); 
                } 
                finally 
                { 
                    conn.Close(); 
                } 
        } 
        catch (Exception ex) 
            { 
                url = @"~/Error.aspx?err=" + Server.UrlEncode(ex.Message) + "&src=" + Server.UrlEncode(ex.StackTrace);  
            } 
            finally 
            { 
                conn.Close(); 
            } 
    } 
    if ( url != "" ) {
        Response.Redirect(url);
    }
    else {
        // Page logic can continue
    }
