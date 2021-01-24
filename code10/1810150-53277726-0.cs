    DateTime date;
    DateTime? LastPasswordDate;
    
    if (DateTime.TryParseExact(row["LastPasswordDate"].ToString(), out date))
    {
        LastPasswordDate = date;
    }
    else
    {
        LastPasswordDate = null;
    }
    insertUserCommand.Parameters.AddWithValue("@LastPasswordDate", (object)LastPasswordDate ?? DBNull.Value);
    insertUserCommand.ExecuteNonQuery();
