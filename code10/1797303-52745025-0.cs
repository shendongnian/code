    public async Task MyMethod()
    {
        await reference.Child("users").Child(userId).SetRawJsonValueAsync(json);
        await reference.Child("users").Child(userId).SetValueAsync(email);
    }
    
