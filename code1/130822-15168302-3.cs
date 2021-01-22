    public static object GetId(this Enum value)
    {
        return Convert.ChangeType(task, Enum.GetUnderlyingType(value.GetType()));
    }
    PersonName person = PersonName.Robert;
    var personId = (short)person.GetId(); 
    // but that sort of defeats the purpose isnt it?
