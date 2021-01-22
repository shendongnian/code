        private StringBuilder lineBuilder;
        public int RegexBufferSize
        {
            set { lastRegexMatchedLength = value; }
            get { return lastRegexMatchedLength; }
        }
        private int lastRegexMatchedLength = 0;
        public virtual string ReadRegex(Regex regex)
        {
            if (base_stream == null)
                throw new ObjectDisposedException("StreamReader", "Cannot read from a closed RegexStreamReader");
            if (pos >= decoded_count && ReadBuffer() == 0)
                return null; // EOF Reached
            if (lineBuilder == null)
                lineBuilder = new StringBuilder();
            else
                lineBuilder.Length = 0;
            lineBuilder.Append(decoded_buffer, pos, decoded_count - pos);
            int bytesRead = ReadBuffer();
            bool dataTested = false;
            while (bytesRead > 0)
            {
                var lineBuilderStartLen = lineBuilder.Length;
                dataTested = false;
                lineBuilder.Append(decoded_buffer, 0, bytesRead);
                if (lineBuilder.Length >= lastRegexMatchedLength)
                {
                    var currentBuf = lineBuilder.ToString();
                    var match = regex.Match(currentBuf, 0, currentBuf.Length);
                    if (match.Success)
                    {
                        var offset = match.Index + match.Length;
                        pos = 0;
                        decoded_count = lineBuilder.Length - offset;
                        ensureMinDecodedBufLen(decoded_count);
                        lineBuilder.CopyTo(offset, decoded_buffer, 0, decoded_count);
                        var matchedString = currentBuf.Substring(match.Index, match.Length);
                        return matchedString;
                    }
                    else
                    {
                        lastRegexMatchedLength *= (int) 1.1; // allow for more space before attempting to match
                        dataTested = true;
                    }
                }
                bytesRead = ReadBuffer();
            }
            // EOF reached
            if (!dataTested)
            {
                var currentBuf = lineBuilder.ToString();
                var match = regex.Match(currentBuf, 0, currentBuf.Length);
                if (match.Success)
                {
                    var offset = match.Index + match.Length;
                    pos = 0;
                    decoded_count = lineBuilder.Length - offset;
                    ensureMinDecodedBufLen(decoded_count);
                    lineBuilder.CopyTo(offset, decoded_buffer, 0, decoded_count);
                    var matchedString = currentBuf.Substring(match.Index, match.Length);
                    return matchedString;
                }
            }
            pos = decoded_count;
            return null;
        }
