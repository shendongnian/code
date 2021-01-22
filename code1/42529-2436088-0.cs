            string sep = "\",\"";
            int columnCount = 0;
            while ((currentLine = sr.ReadLine()) != null)
            {
                if (lineCount == 0)
                {
                    lineData = inLine.Split(new string[] { sep }, StringSplitOptions.None);
                    columnCount = lineData.length;
                    ++lineCount;
                    continue;
                }
                string thisLine = lastLine + currentLine;
                lineData = thisLine.Split(new string[] { sep }, StringSplitOptions.None);
                if (lineData.Length < columnCount)
                {
                    lastLine += currentLine;
                    continue;
                }
                else
                {
                    lastLine = null;
                }
                ......
