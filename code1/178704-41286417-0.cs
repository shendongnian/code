     public static string RemoveAllSpaceAndConcertToPascalCase(string status)
            {
                var textInfo = new System.Globalization.CultureInfo("en-US").TextInfo;
                var titleCaseStr = textInfo.ToTitleCase(status);
                string result = titleCaseStr.Replace("_","").Replace(" ", "");
    
                return result;
            }
