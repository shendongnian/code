    public class HumanizeComparisonType
    {
        public class GetHumanizeComparisonType
        {
            public bool CaseSensitiveCondition;// True - case sensitive, False - case insensitive
            public string
                FirstText
                , SecondText;
        }
    
        public static int HumanizeComparison(GetHumanizeComparisonType GetHumanizeComparison)// 0 - Equal, 1 - The first text is bigger, 2 - The second text is bigger
        {
            GetHumanizeComparisonType FunctionGet = GetHumanizeComparison;
            int
                FunctionResult = 0
                , FirstTextIndex = -1
                , FirstTextNumber
                , FirstTextLength = FunctionGet.FirstText.Length
                , SecondTextIndex = -1
                , SecondTextNumber
                , SecondTextLength = FunctionGet.SecondText.Length
                , SmallestTextLength = FirstTextLength > SecondTextLength ? SecondTextLength : FirstTextLength;
    
            bool MethodFound = false;
    
            for (int TextsIndex = 0; TextsIndex < SmallestTextLength; TextsIndex++)
                if
                (
                    FunctionGet.FirstText[TextsIndex] >= '0' && FunctionGet.FirstText[TextsIndex] <= '9'
                    && FunctionGet.SecondText[TextsIndex] >= '0' && FunctionGet.SecondText[TextsIndex] <= '9'
                )
                {
                    switch (String.Compare(FunctionGet.FirstText, FirstTextIndex + 1, FunctionGet.SecondText, FirstTextIndex + 1, TextsIndex - (FirstTextIndex + 1), FunctionGet.CaseSensitiveCondition == false))
                    {
                        case -1:
                            {
                                MethodFound = true;
    
                                FunctionResult = 2;
    
                                break;
                            }
    
                        case 0:
                            {
                                for (FirstTextIndex = TextsIndex; FirstTextIndex < FirstTextLength - 1; FirstTextIndex++)
                                    if (FunctionGet.FirstText[FirstTextIndex + 1] < '0' || FunctionGet.FirstText[FirstTextIndex + 1] > '9')
                                        break;
    
                                for (SecondTextIndex = TextsIndex; SecondTextIndex < SecondTextLength - 1; SecondTextIndex++)
                                    if (FunctionGet.SecondText[SecondTextIndex + 1] < '0' || FunctionGet.SecondText[SecondTextIndex + 1] > '9')
                                        break;
    
                                FirstTextNumber = int.Parse(FunctionGet.FirstText.Substring(TextsIndex, FirstTextIndex - TextsIndex + 1));
    
                                SecondTextNumber = int.Parse(FunctionGet.SecondText.Substring(TextsIndex, SecondTextIndex - TextsIndex + 1));
    
                                if (FirstTextNumber > SecondTextNumber)
                                {
                                    MethodFound = true;
    
                                    FunctionResult = 1;
                                }
                                else
                                {
                                    if (SecondTextNumber > FirstTextNumber)
                                    {
                                        MethodFound = true;
    
                                        FunctionResult = 2;
                                    }
                                    else
                                    {
                                        if (FirstTextIndex > SecondTextIndex)// checking if there're leading zeroes before the number of the first text
                                        {
                                            MethodFound = true;
    
                                            FunctionResult = 2;
                                        }
                                        else
                                        {
                                            if (SecondTextIndex > FirstTextIndex)// checking if there're leading zeroes before the number of the second text
                                            {
                                                MethodFound = true;
    
                                                FunctionResult = 1;
                                            }
                                            else
                                                TextsIndex = FirstTextIndex;
                                        }
                                    }
                                }
    
                                break;
                            }
    
                        case 1:
                            {
                                MethodFound = true;
    
                                FunctionResult = 1;
    
                                break;
                            }
                    }
    
                    if (MethodFound == true)
                        break;
                }
    
            if (MethodFound == false)
                if (FirstTextIndex < FirstTextLength - 1)
                    if (SecondTextIndex < SecondTextLength - 1)
                        switch (String.Compare(FunctionGet.FirstText.Substring(FirstTextIndex + 1), FunctionGet.SecondText.Substring(FirstTextIndex + 1), FunctionGet.CaseSensitiveCondition == false))
                        {
                            case -1:
                                {
                                    FunctionResult = 2;
    
                                    break;
                                }
    
                            case 1:
                                {
                                    FunctionResult = 1;
    
                                    break;
                                }
                        }
                    else
                        FunctionResult = 1;
                else
                {
                    if (SecondTextIndex < SecondTextLength - 1)// else means that both of the texts are equal, FunctionResult = 0
                        FunctionResult = 2;
                }
    
            return FunctionResult;
        }
    }
