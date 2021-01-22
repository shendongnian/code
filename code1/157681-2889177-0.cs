    string sql = "SELECT 'AUTHOR' = tblAuthors.FIRSTNAME + ' ' + tblAuthors.LASTNAME, tblBooks.*, tblGenres.GENRE "
               + "FROM tblAuthors INNER JOIN tblBooks ON tblAuthors.AUTHOR_ID = tblBooks.AUTHOR_ID INNER JOIN tblGenres ON tblBooks.GENRE_ID = tblGenres.GENRE_ID "
               +"WHERE (tblBooks.TITLE LIKE @title);";
    
    SqlDataAdapter da = new SqlDataAdapter(sql, GetConnectionString());
    da.SelectCommand.Parameters.Add("@title", SqlDbType.Text);
    da.SelectCommand.Parameters["@title"].Value = "%" + title + "%";
