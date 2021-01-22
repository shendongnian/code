        /// <summary>
        /// Validates the email if it follows the valid email format
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        public static bool EmailIsValid(string emailAddress)
        {
            //if string is not null and empty then check for email follow the format
            return string.IsNullOrEmpty(emailAddress)?false : new Regex(@"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$", RegexOptions.IgnoreCase).IsMatch(emailAddress);
        }
