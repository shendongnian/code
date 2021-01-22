        private static string RemoveExcessPeriods(string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;
            if (!text.Contains(".."))
                return text;
            string extension = Path.GetExtension(text);
            string fileName = Path.GetFileNameWithoutExtension(text);
            StringBuilder result = new StringBuilder(text.Length);
            bool inPeriodRun = false;
            for (int index = 0; index < fileName.Length; index++)
            {
                if (inPeriodRun)
                {
                    if (fileName[index] != '.')
                    {
                        inPeriodRun = false;
                        result.Append(fileName[index]);
                    }
                }
                else
                {
                    if (fileName[index] == '.')
                    {
                        inPeriodRun = true;
                        result.Append(' ');
                    }
                    else
                    {
                        result.Append(fileName[index]);
                    }
                }
            }
            return Path.ChangeExtension(result.ToString(), extension);
        }
