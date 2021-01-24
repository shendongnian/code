    public class ChangeTextCaseType
    {
        public class GetChangeTextCaseType
        {
            public int// 0 - remain as it is, 1 - lower cased, 2 - upper cased, 3 - inverted case
                WordsFirstLetterCase
                , WordsRestLettersCase;
            public string SourceText;
        }
        public static string ChangeTextCase(GetChangeTextCaseType GetChangeTextCase)
        {
            GetChangeTextCaseType FunctionGet = GetChangeTextCase;
            string FunctionResult = "";
            if (FunctionGet.SourceText.Length > 0)
            {
                bool StartOfAWord = true;
                if (FunctionGet.SourceText[0] >= 'a' && FunctionGet.SourceText[0] <= 'z')
                {
                    StartOfAWord = false;
                    if (FunctionGet.WordsFirstLetterCase == 2 || FunctionGet.WordsFirstLetterCase == 3)
                        FunctionResult += (char)(FunctionGet.SourceText[0] - 32);
                    else
                        FunctionResult += FunctionGet.SourceText[0];
                }
                else
                {
                    if (FunctionGet.SourceText[0] >= 'A' && FunctionGet.SourceText[0] <= 'Z')
                    {
                        StartOfAWord = false;
                        if (FunctionGet.WordsFirstLetterCase == 1 || FunctionGet.WordsFirstLetterCase == 3)
                            FunctionResult += (char)(FunctionGet.SourceText[0] + 32);
                        else
                            FunctionResult += FunctionGet.SourceText[0];
                    }
                    else
                        FunctionResult += FunctionGet.SourceText[0];
                }
                for (int SourceTextIndex = 1; SourceTextIndex < FunctionGet.SourceText.Length; SourceTextIndex++)
                    if (FunctionGet.SourceText[SourceTextIndex] >= 'a' && FunctionGet.SourceText[SourceTextIndex] <= 'z')
                        if (StartOfAWord == true)
                        {
                            StartOfAWord = false;
                            if (FunctionGet.WordsFirstLetterCase == 2 || FunctionGet.WordsFirstLetterCase == 3)
                                FunctionResult += (char)(FunctionGet.SourceText[SourceTextIndex] - 32);
                            else
                                FunctionResult += FunctionGet.SourceText[SourceTextIndex];
                        }
                        else
                        {
                            if (FunctionGet.WordsRestLettersCase == 2 || FunctionGet.WordsRestLettersCase == 3)
                                FunctionResult += (char)(FunctionGet.SourceText[SourceTextIndex] - 32);
                            else
                                FunctionResult += FunctionGet.SourceText[SourceTextIndex];
                        }
                    else
                    {
                        if (FunctionGet.SourceText[SourceTextIndex] >= 'A' && FunctionGet.SourceText[SourceTextIndex] <= 'Z')
                            if (StartOfAWord == true)
                            {
                                StartOfAWord = false;
                                if (FunctionGet.WordsFirstLetterCase == 1 || FunctionGet.WordsFirstLetterCase == 3)
                                    FunctionResult += (char)(FunctionGet.SourceText[SourceTextIndex] + 32);
                                else
                                    FunctionResult += FunctionGet.SourceText[SourceTextIndex];
                            }
                            else
                            {
                                if (FunctionGet.WordsRestLettersCase == 1 || FunctionGet.WordsRestLettersCase == 3)
                                    FunctionResult += (char)(FunctionGet.SourceText[SourceTextIndex] + 32);
                                else
                                    FunctionResult += FunctionGet.SourceText[SourceTextIndex];
                            }
                        else
                        {
                            if (StartOfAWord == false)
                                StartOfAWord = true;
                            FunctionResult += FunctionGet.SourceText[SourceTextIndex];
                        }
                    }
            }
            return FunctionResult;
        }
    }
