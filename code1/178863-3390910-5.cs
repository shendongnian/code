        private static string RemoveExcessPeriods(string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;
            // If there are no consecutive periods, then just get out of here.
            if (!text.Contains(".."))
                return text;
            // To keep things simple, let's separate the file name from its extension.
            string extension = Path.GetExtension(text);
            string fileName = Path.GetFileNameWithoutExtension(text);
            StringBuilder result = new StringBuilder(text.Length);
            bool lastCharacterWasPeriod = false;
            bool thisCharacterIsPeriod = fileName.Length > 0 && fileName[0] == '.';
            bool nextCharacterIsPeriod;
            for (int index = 0; index < fileName.Length; index++)
            {
                // Includes both the extension separator and other periods.
                nextCharacterIsPeriod = fileName.Length == index + 1 || fileName[index + 1] == '.';
                if (!thisCharacterIsPeriod)
                    result.Append(fileName[index]);
                else if (thisCharacterIsPeriod && !lastCharacterWasPeriod && !nextCharacterIsPeriod)
                    result.Append('.');
                else if (thisCharacterIsPeriod && !lastCharacterWasPeriod)
                    result.Append(' ');
                lastCharacterWasPeriod = thisCharacterIsPeriod;
                thisCharacterIsPeriod = nextCharacterIsPeriod;
            }
            return result.ToString() + extension;
        }
