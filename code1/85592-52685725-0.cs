        public static bool IsEmail(this string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return false;
            // MUST CONTAIN ONE AND ONLY ONE @
            var atCount = input.Count(c => c == '@');
            if (atCount != 1) return false;
            // MUST CONTAIN PERIOD
            if (!input.Contains(".")) return false;
            // @ MUST OCCUR BEFORE LAST PERIOD
            var indexOfAt = input.IndexOf("@", StringComparison.Ordinal);
            var lastIndexOfPeriod = input.LastIndexOf(".", StringComparison.Ordinal);
            var atBeforeLastPeriod = lastIndexOfPeriod > indexOfAt;
            if (!atBeforeLastPeriod) return false;
            // CODE FROM COGWHEEL'S ANSWER: https://stackoverflow.com/a/1374644/388267 
            try
            {
                var addr = new System.Net.Mail.MailAddress(input);
                return addr.Address == input;
            }
            catch
            {
                return false;
            }
        }
