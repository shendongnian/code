    public static string SeperateByCamelCase(this string text, char splitChar = ' ') {
            var output = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                var c = text[i];
                //if not the first and the char is upper
                if (i > 0 && char.IsUpper(c)) {
                    var wasLastLower = char.IsLower(text[i - 1]);
                    if (i + 1 < text.Length) //is there a next
                    {
                        var isNextUpper = char.IsUpper(text[i + 1]);
                        if (!isNextUpper) //if next is not upper (start of a word).
                        {
                            output.Append(splitChar);
                        }
                        else if (wasLastLower) //last was lower but i'm upper and my next is an upper (start of an achromin). 'abcdHTTP' 'abcd HTTP'
                        {
                            output.Append(splitChar);
                        }
                    }
                    else
                    {
                        //last letter - if its upper and the last letter was lower 'abcd' to 'abcd A'
                        if (wasLastLower)
                        {
                            output.Append(splitChar);
                        }
                    }
                }
                output.Append(c);
            }
            return output.ToString();
        }
