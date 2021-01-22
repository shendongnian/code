    public static string[] GetFieldsFromString(string csvString)
        {
            using (var stringAsReader = new StringReader(csvString))
            {
                using (var textFieldParser = new TextFieldParser(stringAsReader))
                {
                    SetUpTextFieldParser(textFieldParser, FieldType.Delimited, new[] {","}, false, true);
                    try
                    {
                        return textFieldParser.ReadFields();
                    }
                    catch (MalformedLineException ex1)
                    {
                        //assume it's not parseable due to double quotes, so we strip them all out and take what we have
                        var sanitizedString = csvString.Replace("\"", "");
                        using (var sanitizedStringAsReader = new StringReader(sanitizedString))
                        {
                            using (var textFieldParser2 = new TextFieldParser(sanitizedStringAsReader))
                            {
                                SetUpTextFieldParser(textFieldParser2, FieldType.Delimited, new[] {","}, false, true);
                                try
                                {
                                    return textFieldParser2.ReadFields().Select(part => part.Trim()).ToArray();
                                }
                                catch (MalformedLineException ex2)
                                {
                                    return new string[] {csvString};
                                }
                            }
                        }
                    }
                }
            }
        }
