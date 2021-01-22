    public static object IsNull(object Value, object InsteadVlue)
    {
        return (Value == DBNull.Value ? null : Value) ?? InsteadVlue;
    }
    //This method can work with DBNull and null value. This method is question's answer
