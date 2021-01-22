    // myLanguageDictionaries is of type IDictionary<ILanguage, IDictionary<string, string>>
    foreach (var dictionary in myLanguageDictionaries.Keys)
    {
      myLanguageDictionaries[dictionary].Value = 
          ConvertKeysToLowerCase(myLanguageDictionaries[dictionary].Value);
    }
    
