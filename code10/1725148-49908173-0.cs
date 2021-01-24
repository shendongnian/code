     internal void LoadLanguageFile()
     {
          var languageCode = ApplicationSetting.LanguageCode;
          if (string.IsNullOrEmpty(languageCode) == false)
          {
                var dictionariesToRemove = new List<ResourceDictionary>();
    
                foreach (var dictionary in Application.Current.Resources.MergedDictionaries)
                {
                    if (dictionary.Source.ToString().Contains(@"/Strings.") == true)
                        dictionariesToRemove.Add(dictionary);
                }
    
                foreach (var item in dictionariesToRemove)
                    Application.Current.Resources.MergedDictionaries.Remove(item);
    
                var languageDictionary = new ResourceDictionary()
                {
                    Source = new Uri($"/SomeApp;component/Assets/Languages/Strings.{languageCode}.xaml", UriKind.Relative)
                };
        
        Application.Current.Resources.MergedDictionaries.Add(languageDictionary);
    
                }
            }
