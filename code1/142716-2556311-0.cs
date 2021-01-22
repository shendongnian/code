    internal void UpdateCash(int cashID, int id, FieldName field)
    {
        using (OurCustomDbConnection conn = CreateConnection("UpdateCash"))
        {
            conn.CommandText = string.format("update Cash set {0} = @id where id = @cashID", field.ToString());
    
            conn.AddParam("@id", id);
            conn.AddParam("@cashId", cashId);
    
            conn.ExecuteNonQuery();
        }
    }
    public enum FieldName
    {
        PayPalCaptureId,
        PayPalTransactionInfoID
    }
