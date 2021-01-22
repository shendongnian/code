    public static object GetValue(Enum e)
    {
        return e.GetType().GetField("value__").GetValue(e);
    }
    Debug.Assert(Equals(GetValue(DayOfWeek.Wednesday), 3));                //Int32
    Debug.Assert(Equals(GetValue(AceFlags.InheritOnly), (byte) 8));        //Byte
    Debug.Assert(Equals(GetValue(IOControlCode.ReceiveAll), 2550136833L)); //Int64
