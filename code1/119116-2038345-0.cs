    public IEnumerable<PropertyInfo> GetPropertiesToTransfer( User user );
    {
        Type userType = user.GetType();
        Type clientAvailableType = typeof(ClientAvailableUser);
    
        PropertyInfo[] userProps = userType.GetProperties();
        IEnumerable<string> caUserProps = clientAvailableType.GetProperties().Select( p => p.Name );
    
        return userProps.Where( p => caUserProps.Contains( p.Name ) );
    }
