        public IEnumerable<string> SplitCSV(string line)
        {
            int index = 0;
            int start = 0;
            bool inString = false;
            foreach (char c in line)
            {
                switch (c)
                {
                    case '"':
                        inString = !inString;
                        break;
                    case ',':
                        yield return line.Substring(start, index - start);
                        start = index + 1;
                        break;
                }
                index++;
            }
            if (start < index)
                yield return line.Substring(start, index - start);
        }
