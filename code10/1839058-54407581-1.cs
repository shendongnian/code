    public List<T> RetrieveCharacterListFromApi<T>(Guid gameId)
    {
        List<T> returnValue = default(List<T>);
        var getCharacterResponse = GetCharacters(gameId);
        var results = getCharacterResponse.Result;
        // 'ListCharacterResponse' does not contain a definition for 'ToList'.
        foreach(Character character in results)
            returnValue.Add(character);
    
        return returnValue;
    }
