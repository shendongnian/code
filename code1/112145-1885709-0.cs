     Regex ElementExpression = new Regex(
                @"<(?'tag'\w+?).*>" + // match first tag, and name it 'tag'
                @"(?'text'[^<>]*?)" + // match text content, name it 'text'
                @"</\k'tag'>" // match last tag, denoted by 'tag'
                , RegexOptions.Multiline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            Regex WhiteSpaceExpression = new Regex(@"\A((&nbsp;)|(\s)|(\r))*\Z", RegexOptions.Multiline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            MatchCollection elementMatches =ElementExpression.Matches(text);
            int elementCount = 0;
            foreach(Match elementMatch in elementMatches)
            {
                if(elementMatch.Groups.Count > 0)
                {
                    Group textGroup = elementMatch.Groups["text"];
                    if (!WhiteSpaceExpression.IsMatch(textGroup.Value))
                    {
                        elementCount++;
                        string value = textGroup.Value;
                    }
                }
            }
