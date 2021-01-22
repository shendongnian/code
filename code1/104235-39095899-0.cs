        public static string ExtractString(string soapMessage, string tag)
        {
            if (string.IsNullOrEmpty(soapMessage))
                return soapMessage;
            var startTag = "<" + tag + ">";
            int startIndex = soapMessage.IndexOf(startTag);
			startIndex = startIndex == -1 ? 0 : startIndex + startTag.Length;
            int endIndex = soapMessage.IndexOf("</" + tag + ">", startIndex);
			endIndex = endIndex > soapMessage.Length || endIndex == -1 ? soapMessage.Length : endIndex;
            return soapMessage.Substring(startIndex, endIndex - startIndex);
        }
