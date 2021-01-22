    public void removeMediaMsg(long userId, long msgId)
    {
        using (var dbTrans = connection.BeginTransaction())
        {
            command.CommandText = "DELETE FROM user_media_subscription "
                + "WHERE msgId=@msgId AND recipientId=@recipientId;";
            command.Parameters.Add("@msgId", DbType.Int64).Value = msgId;
            command.Parameters.Add("@recipientId", DbType.Int64).Value = userId;
            int affected = command.ExecuteNonQuery();
            if (affected == 1) {
                command.CommandText = "UPDATE user_data SET mediaMsgCount=mediaMsgCount-1 WHERE userId=@userId;";
                command.Parameters.Add("@userId", DbType.Int64).Value = userId;
                command.ExecuteNonQuery();
            }
            dbTrans.Commit();    
        }
    }
