    string iso6391TwoLetterCode = InputLanguage.CurrentInputLanguage.Culture.TwoLetterISOLanguageName;
    
    switch(iso6391TwoLetterCode)
    {
        case "ru":
            Console.WriteLine("Russian is defined!");
            break;
        case "en":
            Console.WriteLine("English is defined!");
            break;
        case "de":
            Console.WriteLine("German is defined!");
            break;
        default:
            Console.WriteLine("Some other language is defined!");
            break;
    }
