       /// <summary>
        /// Removes all html tags from string and leaves only plain text
        /// Removes content of <xml></xml> and <style></style> tags as aim to get text content not markup /meta data.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string HtmlStrip(this string input)
        {
            input = Regex.Replace(input, "<style>(.|\n)*?</style>",string.Empty);
            input = Regex.Replace(input, @"<xml>(.|\n)*?</xml>", string.Empty); // remove all <xml></xml> tags and anything inbetween.  
            return Regex.Replace(input, @"<(.|\n)*?>", string.Empty); // remove any tags but not there content "<p>bob<span> johnson</span></p>" becomes "bob johnson"
        }
   
