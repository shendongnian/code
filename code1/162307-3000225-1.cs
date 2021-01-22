            private string ReplaceLine(string allLines, int lineNumber, string newLine)
        {
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(Environment.NewLine);
            string newLines = "";
            string[] lines = reg.Split(allLines);
            int lineCnt = 0;
            foreach (string oldLine in lines)
            {
                lineCnt++;
                if (lineCnt == lineNumber)
                {
                    newLines += newLine;
                }
                else
                {
                    newLines += oldLine;
                }
                newLines += lineCnt == lines.Count() ? "" : Environment.NewLine;
            }
            return newLines;
        }
