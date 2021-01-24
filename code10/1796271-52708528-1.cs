    using System.Collections.Generic;
    using System.Linq;
    
    namespace TextAnalysis
    {
        static class SentencesParserTask
        {
            public static List<List<string>> ParseSentences(string text)
            {
                var sentencesList = new List<List<string>>();
                var splittedText = text.Split('.', '!', '?', ';', ':', '(', ')');
    
                foreach (var sentence in splittedText)
                {
                    var wordsArray = sentence.Split('^', '#', '$', '-', '+', '1', '=', ' ', '\t', '\n', '\r', ',');
                    var additionalMainList = new List<string>();
                    var wordList = new List<string>();
                    foreach (var word in wordsArray)
                    {
                        if (word != string.Empty)
                        {
                            var fineWord = word;
                            wordList.Add(fineWord.ToLower());
                            additionalMainList.Add(fineWord.ToLower());
                        }
                    }
                    bool isEmpty = !(wordList).Any();
                    if (!isEmpty)
                        sentencesList.Add(additionalMainList);
                    wordList.Clear();
                }
    
                return sentencesList;
            }
        }
    
    }
