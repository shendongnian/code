     public static string FormatTwitterText(this string text, string shareurl)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;
            string finaltext = string.Empty;
            string sharepath = string.Format("http://url.com/{0}", shareurl);
            
            //list of all words, trimmed and new space removed
            List<string> textlist = text.Split(' ').Select(txt => Regex.Replace(txt, @"\n", "").Trim())
                                  .Where(formatedtxt => !string.IsNullOrEmpty(formatedtxt))
                                  .ToList();
            int extraChars = 3; //to account for the two dots ".."
            int finalLength = 140 - sharepath.Length - extraChars;
            int runningLengthCount = 0;
            int collectionCount = textlist.Count;
            int count = 0;
            foreach (string eachwordformated in textlist
                    .Select(eachword => string.Format("{0} ", eachword)))
            {
                count++;
                int textlength = eachwordformated.Length;
                runningLengthCount += textlength;
                int nextcount = count + 1;
                var nextTextlength = nextcount < collectionCount ? 
                                                 textlist[nextcount].Length : 
                                                 0;
                if (runningLengthCount + nextTextlength < finalLength)
                    finaltext += eachwordformated;
            }
            return runningLengthCount > finalLength ? finaltext.Trim() + ".." : finaltext.Trim();
        }
