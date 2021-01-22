    public void ToPinyinput()
            {
                    string CName= "";
                    foreach(InputLanguage lang in InputLanguage.InstalledInputLanguages) 
                    {
                            CName = lang.Culture.EnglishName.ToString();
    
                            if(CName.StartsWith("Pinyinput"))
                            {
                                    InputLanguage.CurrentInputLanguage = lang;
                            }
                    }
    
            }
    public void Tosogou()
            {
                    string CName= "";
                    foreach(InputLanguage lang in InputLanguage.InstalledInputLanguages) 
                    {
                            CName = lang.Culture.EnglishName.ToString();
    
                            if(CName.StartsWith("sogou"))
                            {
                                    InputLanguage.CurrentInputLanguage = lang;
                            }
                    }
    
            }
