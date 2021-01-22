     static string SanitizeInput(string searchPhrase, int maxLength)
            {
                Regex r = new Regex(@";|'|--|xp_|/\*|\*/", RegexOptions.Compiled);
                return r.Replace(searchPhrase.Substring(0, searchPhrase.Length > maxLength ? maxLength : searchPhrase.Length), " ");
            }
    
            static string SanitizeInput(string searchPhrase)
            {
                const int MAX_SEARCH_PHRASE_LENGTH = 200;
                return SanitizeInput(searchPhrase, MAX_SEARCH_PHRASE_LENGTH);
            }
