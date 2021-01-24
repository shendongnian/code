           // Encoding = EncodeType,
            //SampleRateHertz = Int32.Parse(SampleRate),                
            LanguageCode = Lang,
           // EnableAutomaticPunctuation = true,
            //EnableWordTimeOffsets = true,
            MaxAlternatives = 5,
            Model= "default"
        };
        //add one or more alternative language codes
        RecogCfg.AlternativeLanguageCodes.Add("<Language Code 1>");
        RecogCfg.AlternativeLanguageCodes.Add("<Language Code 2>");
