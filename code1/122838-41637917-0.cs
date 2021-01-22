    /// <summary>
    /// The fast HTML text extractor class is designed to, as quickly and as ignorantly as possible,
    /// extract text data from a given HTML character array. The class searches for and deletes
    /// script and style tags in a first and second pass, with an optional third pass to do the same
    /// to HTML comments, and then copies remaining non-whitespace character data to an ouput array.
    /// All whitespace encountered is replaced with a single whitespace in to avoid multiple
    /// whitespace in the output.
    ///
    /// Note that the returned text content still may have named character and numbered character
    /// references within that, when decoded, may produce multiple whitespace.
    /// </summary>
    public class FastHtmlTextExtractor
    {
    
        private readonly char[] SCRIPT_OPEN_TAG = new char[7] { '<', 's', 'c', 'r', 'i', 'p', 't' };
        private readonly char[] SCRIPT_CLOSE_TAG = new char[9] { '<', '/', 's', 'c', 'r', 'i', 'p', 't', '>' };
    
        private readonly char[] STYLE_OPEN_TAG = new char[6] { '<', 's', 't', 'y', 'l', 'e' };
        private readonly char[] STYLE_CLOSE_TAG = new char[8] { '<', '/', 's', 't', 'y', 'l', 'e', '>' };
    
        private readonly char[] COMMENT_OPEN_TAG = new char[3] { '<', '!', '-' };
        private readonly char[] COMMENT_CLOSE_TAG = new char[3] { '-', '-', '>' };
    
        private int[] m_deletionDictionary;
    
        public string Extract(char[] input, bool stripComments = false)
        {
            var len = input.Length;
            int next = 0;
    
            m_deletionDictionary = new int[len];
    
            // Whipe out all text content between style and script tags.
            FindAndWipe(SCRIPT_OPEN_TAG, SCRIPT_CLOSE_TAG, input);
            FindAndWipe(STYLE_OPEN_TAG, STYLE_CLOSE_TAG, input);
    
            if(stripComments)
            {
                // Whipe out everything between HTML comments.
                FindAndWipe(COMMENT_OPEN_TAG, COMMENT_CLOSE_TAG, input);
            }
    
            // Whipe text between all other tags now.
            while(next < len)
            {
                next = SkipUntil(next, '<', input);
    
                if(next < len)
                {
                    var closeNext = SkipUntil(next, '>', input);
    
                    if(closeNext < len)
                    {
                        m_deletionDictionary[next] = (closeNext + 1) - next;
                        WipeRange(next, closeNext + 1, input);
                    }
    
                    next = closeNext + 1;
                }
            }
    
            // Collect all non-whitespace and non-null chars into a new
            // char array. All whitespace characters are skipped and replaced
            // with a single space char. Multiple whitespace is ignored.
            var lastSpace = true;
            var extractedPos = 0;
            var extracted = new char[len];
    
            for(next = 0; next < len; ++next)
            {
                if(m_deletionDictionary[next] > 0)
                {
                    next += m_deletionDictionary[next];
                    continue;
                }
    
                if(char.IsWhiteSpace(input[next]) || input[next] == '\0')
                {
                    if(lastSpace)
                    {
                        continue;
                    }
    
                    extracted[extractedPos++] = ' ';
                    lastSpace = true;
                }
                else
                {
                    lastSpace = false;
                    extracted[extractedPos++] = input[next];
                }
            }
    
            return new string(extracted, 0, extractedPos);
        }
    
        /// <summary>
        /// Does a search in the input array for the characters in the supplied open and closing tag
        /// char arrays. Each match where both tag open and tag close are discovered causes the text
        /// in between the matches to be overwritten by Array.Clear().
        /// </summary>
        /// <param name="openingTag">
        /// The opening tag to search for.
        /// </param>
        /// <param name="closingTag">
        /// The closing tag to search for.
        /// </param>
        /// <param name="input">
        /// The input to search in.
        /// </param>
        private void FindAndWipe(char[] openingTag, char[] closingTag, char[] input)
        {
            int len = input.Length;
            int pos = 0;
    
            do
            {
                pos = FindNext(pos, openingTag, input);
    
                if(pos < len)
                {
                    var closenext = FindNext(pos, closingTag, input);
    
                    if(closenext < len)
                    {
                        m_deletionDictionary[pos - openingTag.Length] = closenext - (pos - openingTag.Length);
                        WipeRange(pos - openingTag.Length, closenext, input);
                    }
    
                    if(closenext > pos)
                    {
                        pos = closenext;
                    }
                    else
                    {
                        ++pos;
                    }
                }
            }
            while(pos < len);
        }
    
        /// <summary>
        /// Skips as many characters as possible within the input array until the given char is
        /// found. The position of the first instance of the char is returned, or if not found, a
        /// position beyond the end of the input array is returned.
        /// </summary>
        /// <param name="pos">
        /// The starting position to search from within the input array.
        /// </param>
        /// <param name="c">
        /// The character to find.
        /// </param>
        /// <param name="input">
        /// The input to search within.
        /// </param>
        /// <returns>
        /// The position of the found character, or an index beyond the end of the input array.
        /// </returns>
        private int SkipUntil(int pos, char c, char[] input)
        {
            if(pos >= input.Length)
            {
                return pos;
            }
    
            do
            {
                if(input[pos] == c)
                {
                    return pos;
                }
    
                ++pos;
            }
            while(pos < input.Length);
    
            return pos;
        }
    
        /// <summary>
        /// Clears a given range in the input array.
        /// </summary>
        /// <param name="start">
        /// The start position from which the array will begin to be cleared.
        /// </param>
        /// <param name="end">
        /// The end position in the array, the position to clear up-until.
        /// </param>
        /// <param name="input">
        /// The source array wherin the supplied range will be cleared.
        /// </param>
        /// <remarks>
        /// Note that the second parameter is called end, not lenghth. This parameter is meant to be
        /// a position in the array, not the amount of entries in the array to clear.
        /// </remarks>
        private void WipeRange(int start, int end, char[] input)
        {
            Array.Clear(input, start, end - start);
        }
    
        /// <summary>
        /// Finds the next occurance of the supplied char array within the input array. This search
        /// ignores whitespace.
        /// </summary>
        /// <param name="pos">
        /// The position to start searching from.
        /// </param>
        /// <param name="what">
        /// The sequence of characters to find.
        /// </param>
        /// <param name="input">
        /// The input array to perform the search on.
        /// </param>
        /// <returns>
        /// The position of the end of the first matching occurance. That is, the returned position
        /// points to the very end of the search criteria within the input array, not the start. If
        /// no match could be found, a position beyond the end of the input array will be returned.
        /// </returns>
        public int FindNext(int pos, char[] what, char[] input)
        {
            do
            {
                if(Next(ref pos, what, input))
                {
                    return pos;
                }
                ++pos;
            }
            while(pos < input.Length);
    
            return pos;
        }
    
        /// <summary>
        /// Probes the input array at the given position to determine if the next N characters
        /// matches the supplied character sequence. This check ignores whitespace.
        /// </summary>
        /// <param name="pos">
        /// The position at which to check within the input array for a match to the supplied
        /// character sequence.
        /// </param>
        /// <param name="what">
        /// The character sequence to attempt to match. Note that whitespace between characters
        /// within the input array is accebtale.
        /// </param>
        /// <param name="input">
        /// The input array to check within.
        /// </param>
        /// <returns>
        /// True if the next N characters within the input array matches the supplied search
        /// character sequence. Returns false otherwise.
        /// </returns>
        public bool Next(ref int pos, char[] what, char[] input)
        {
            int z = 0;
    
            do
            {
                if(char.IsWhiteSpace(input[pos]) || input[pos] == '\0')
                {
                    ++pos;
                    continue;
                }
    
                if(input[pos] == what[z])
                {
                    ++z;
                    ++pos;
                    continue;
                }
    
                return false;
            }
            while(pos < input.Length && z < what.Length);
    
            return z == what.Length;
        }
    }
