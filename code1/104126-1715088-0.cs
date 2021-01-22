            string blah = "hoi <strong>dit <em>is test bla meer tekst</em></strong>";
            int aantalChars = 10;
            bool inTag = false;
            int cntr = 0;
            int cntrContent = 0;
            foreach (Char c in blah)
            {
                if (cntrContent == aantalChars) break;
                cntr++;
                if (c == '<')
                {
                    inTag = true;
                    continue;
                }
                else if (c == '>')
                {
                    inTag = false;
                    continue;
                }
                if (!inTag) cntrContent++;
            }
            string substr = blah.Substring(0, cntr);
            //search for nonclosed tags
            MatchCollection openedTags = new Regex("<[^/](.|\n)*?>").Matches(substr);
            MatchCollection closedTags = new Regex("<[/](.|\n)*?>").Matches(substr);
            for (int i =openedTags.Count - closedTags.Count; i >= 1; i--)
            {
                string closingTag = "</" + openedTags[closedTags.Count + i - 1].Value.Substring(1);
                substr += closingTag;
            }
