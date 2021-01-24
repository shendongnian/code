    public JObject SomeMethod(JObject obj)
    {
        if ( /* condition here */ )
        {
            obj.Remove("accepted");
        }
        else
        {
            obj.Remove("declined");
        }
        return obj;
    }
