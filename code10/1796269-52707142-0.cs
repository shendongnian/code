    public static List<List<string>> ParseSentences(string text)
    {
        var sentencesList = new List<List<string>>();                    
        var splittedText = text.Split('.', '!', '?', ';', ':', '(', ')');
        List<string>[] mas = new List<string>[splittedText.Length];
        for (int i = 0; i < splittedText.Length; i++)
        {
            mas[i] = new List<string>();
        }
        for (int j = 0; j < splittedText.Length; j++)
        {
            //Passes entire splittedText:
            mas[j]= GetWordsOutOfTheSentence(splittedText);
            //Passes just the relevant sentence
            mas[j]= GetWordsOutOfTheSentence(splittedText[j]);
            bool isEmpty = !(mas[j]).Any();
            if(!isEmpty)
            sentencesList.Add(mas[j]);
        }
        return sentencesList;
    }
