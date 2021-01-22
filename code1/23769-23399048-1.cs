        public static string Combine(params string[] parts)
        {
            if (parts == null) throw new ArgumentNullException("parts");
            int index = 0;
            string firstPart = parts[index];
            if (string.IsNullOrEmpty(firstPart)) throw new FirstPartInArgumentIsNullOrEmptyException();
            var finalUri = new System.Uri(firstPart);
            var rootUri = new System.Uri(finalUri.GetLeftPart(UriPartial.Authority));
            var rightPart = rootUri.MakeRelativeUri(finalUri);
            var lastPartsBuilder = new StringBuilder(rightPart.ToString());
            for (index = 1; index < parts.Length; index++)
            {
                string current = parts[index];
                if (string.IsNullOrEmpty(current)) continue;
                if (!current.StartsWith(SEPARATOR_FORWARD_SLASH))
                {
                    lastPartsBuilder.Append(SEPARATOR_FORWARD_SLASH);
                }
                lastPartsBuilder.Append(current);
            }
            finalUri = new System.Uri(rootUri, lastPartsBuilder.ToString());
            return finalUri.ToString();
        }
