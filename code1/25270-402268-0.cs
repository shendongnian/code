    public static T AttachDiaryCredentialHeader<T>() where T: class
    {
        T ch = new T();
        Type objType = ch.GetType();
        PropertyInfo userId = objType.GetProperty("UserId");
        authType.SetValue(ch, "myUsername", null)
        //And so on for the other properties...
        return ch;
    }
