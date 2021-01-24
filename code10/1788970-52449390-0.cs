    public enum ActorField
    {
        FirstName,
        LastName,
        Salutation
    }
    
    public void UpdateActorField(string OldName, string NewName, ActorField FieldId)
    {
        string sql = "update actor set {0} = :NEW_NAME where {0} = :OLD_NAME";
    
        switch (FieldId)
        {
            case ActorField.FirstName
                sql = string.Format(sql, "first_name");
                break;
            case ActorField.LastName
                sql = string.Format(sql, "last_name");
                break;
            case ActorField.Salutation
                sql = string.Format(sql, "salutation");
                break;
        }
    
        using (NpgsqlCommand cmd = new NpgsqlCommand(sql, connection))
        {
            cmd.Parameters.AddWithValue("NEW_NAME", NewName);
            cmd.Parameters.AddWithValue("OLD_NAME", OldName);
    
            int updatedRows = cmd.ExecuteNonQuery();
        }
    }
