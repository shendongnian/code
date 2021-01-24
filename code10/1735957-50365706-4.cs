    private async Task<bool> IsFileExisted(string fileName)
    {
        var result= await ApplicationData.Current.LocalFolder.TryGetItemAsync(fileName);
        if (result == null)
        {
            return false;
        }
        return true;
    }
