        /// <summary>
        /// Validates that the URL text can be parsed.
        /// </summary>
        /// <remarks>
        /// Does not validate that it actually points to anything useful.
        /// </remarks>
        /// <param name="urlText">The URL text.</param>
        /// <returns></returns>
        private bool ValidateURL(string urlText)
        {
            bool result;
            try
            {
                Uri check = new Uri(urlText);
                result = true;
            }
            catch (UriFormatException)
            {
                result = false;
            }
            return result;
        }
